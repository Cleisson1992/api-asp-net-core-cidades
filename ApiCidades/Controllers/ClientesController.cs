using ApiCidades.Data;
using ApiCidades.Data.Dtos;
using ApiCidades.Models;
using AutoMapper;
using Cidades.API.Filtro;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiCidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        #region Utilização do contexto(Bd) e mapeamento da Api

        private ApiCidadeContext _context;
        private IMapper _mapper;

        public ClientesController(ApiCidadeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion


        #region Cadastrar cliente

        [HttpPost]
        public IActionResult CadastrarCliente([FromBody] ClienteCreateDto clienteDto)
        {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
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
        [ProducesResponseType(statusCode: 500, Type = typeof(ErroResponse))]
        [ProducesResponseType(statusCode: 404)]
        public IActionResult ConsultarClientePorId(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente != null)
            {
                ClienteReadDto clienteDto = _mapper.Map<ClienteReadDto>(cliente);

                return Ok(clienteDto);
            }

            return NotFound();
        }

        /// <summary>
        /// Consultar cliente pelo nome completo ou consultar todos os clientes
        /// </summary>
        /// <param name="clientesFiltro"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarClientePorNome([FromQuery] ClientesFiltro clientesFiltro)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.NomeCompleto == clientesFiltro.NomeCompleto);

            if (cliente != null)
            {
                ClienteReadDto clienteDto = _mapper.Map<ClienteReadDto>(cliente);

                return Ok(clienteDto);
            }

            if (_context.Clientes != null)
            {
                return Ok(_context.Clientes);
            }

            return NotFound();
        }


        #endregion


        #region Atualizar algum dado do cliente

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, [FromBody] ClienteUpdateDto clienteDto)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return NoContent();
        }

        #endregion


        #region Remover um cliente

        [HttpDelete("{id}")]
        public IActionResult DeletaCliente(int id)
        {
            Cliente cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }

        #endregion

    }
}
