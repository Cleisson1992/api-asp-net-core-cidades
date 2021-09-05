using ApiCidades.Data;
using ApiCidades.Data.Dtos;
using ApiCidades.Data.Dtos.Request;
using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using ApiCidades.Domain.UserCase.UserCaseCliente.Altera;
using ApiCidades.Domain.UserCase.UserCaseCliente.Cadastro;
using ApiCidades.Domain.UserCase.UserCaseCliente.Consulta;
using ApiCidades.Domain.UserCase.UserCaseCliente.Remove;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiCidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        #region Utilização do contexto(Bd) e mapeamento da Api

        private readonly IRepository _repo;
        private readonly ICadastroDeCliente _cadastroDeCliente;
        private readonly IConsultaDeCliente _consultaDeCliente;
        private readonly IAlteraCliente _alteraCliente;
        private readonly IRemoveCliente _removeCliente;
        private readonly ILogger<ClientesController> _logger;
        private IMapper _mapper;

        public ClientesController(IRepository repo, ICadastroDeCliente cadastroDeCliente, IConsultaDeCliente consultaDeCliente, IAlteraCliente alteraCliente, IRemoveCliente removeCliente, ILogger<ClientesController> logger, IMapper mapper)
        {

            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));

            _cadastroDeCliente = cadastroDeCliente??
                throw new ArgumentNullException(nameof(cadastroDeCliente));

            _consultaDeCliente = consultaDeCliente??
                throw new ArgumentNullException(nameof(consultaDeCliente));

            _alteraCliente = alteraCliente??
                throw new ArgumentNullException(nameof(alteraCliente));

            _removeCliente = removeCliente??
                throw new ArgumentNullException(nameof(removeCliente));

            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        #endregion


        #region Cadastrar cliente

        [HttpPost]
        public IActionResult CadastrarCliente([FromBody] ClienteCreateDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);

            if (cliente is null)
            {
                return NotFound();
            }

            _cadastroDeCliente.CadastrarCliente(cliente);
    
            return CreatedAtAction(nameof(ConsultarClientePorId), new { Id = cliente.Id }, cliente);
        }

        #endregion


        #region Consultar cliente 

        /// <summary>
        /// Consultar cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: 200, Type = typeof(ClienteReadDto))]
        //[ProducesResponseType(statusCode: 500, Type = typeof(ErroResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult ConsultarClientePorId(int id)
        {
            var cliente = _consultaDeCliente.ConsultarClientePorId(id);

            if(cliente is null)
            {
                return NotFound();
            }

            var clienteDto = _mapper.Map<ClienteReadDto>(cliente);

            return Ok(clienteDto);
        }

        /// <summary>
        /// Consultar cliente pelo nome completo ou consultar todos os clientes
        /// </summary>
        /// <param name="clientesFiltro"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarClientePorNome([FromQuery] ClientesRequest clientesRequest)
        {
            var clientePorNome = _consultaDeCliente.ConsultarClientePorNomeCompleto(clientesRequest.NomeCompleto);

            if (clientePorNome is null)
            {
                return NotFound();
            }

            var clienteDto = _mapper.Map<ClienteReadDto>(clientePorNome);

            if (clienteDto is null)
            {
                return NoContent();
            }

            return Ok(clienteDto);
        }


        #endregion


        #region Atualizar algum dado do cliente

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] ClienteUpdateDto clienteDto)
        {

            var cliente = _consultaDeCliente.ConsultarClientePorId(id);

            if (cliente is null)
            {
                return NotFound();
            }

            _alteraCliente.AlterarCliente(_mapper.Map(clienteDto, cliente));

            return NoContent();
        }

        #endregion


        #region Remover um cliente

        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id)
        {
            var cliente = _consultaDeCliente.ConsultarClientePorId(id);

            if (cliente is null)
            {
                return NotFound();
            }

            _removeCliente.RemoverCliente(cliente);

            return NoContent();
        }

        #endregion

    }
}
