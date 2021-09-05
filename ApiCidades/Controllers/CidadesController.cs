using ApiCidades.Data.Dtos;
using ApiCidades.Data.Dtos.Request;
using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using ApiCidades.Domain.UserCase.UserCaseCidade.Cadastro;
using ApiCidades.Domain.UserCase.UserCaseCidade.Consulta;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ApiCidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadesController : ControllerBase
    {

        #region Utilização do contexto(Bd) e mapeamento da Api

        private readonly IRepository _repo;
        private readonly IConsultaDeCidade _consultaDeCidade;
        private readonly ICadastroDeCidade _cadastroDeCidade;
        private readonly ILogger<CidadesController> _logger;
        private IMapper _mapper;

        public CidadesController(IRepository repo, IConsultaDeCidade consultaDeCidade, ICadastroDeCidade cadastroDeCidade, ILogger<CidadesController> logger, IMapper mapper)
        {
            _repo = repo ??
                throw new ArgumentNullException(nameof(repo));

            _consultaDeCidade = consultaDeCidade ??
                throw new ArgumentNullException(nameof(consultaDeCidade));

            _cadastroDeCidade = cadastroDeCidade ??
                throw new ArgumentNullException(nameof(cadastroDeCidade));

            _logger = logger ??
                  throw new ArgumentNullException(nameof(logger));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        #endregion


        #region Cadastrar cidade

        [HttpPost]
        public IActionResult CadastrarCidade([FromBody] CidadeCreateDto cidadeDto)
        {
            Cidade cidade = _mapper.Map<Cidade>(cidadeDto);

            if (cidade is null)
            {
                return NotFound();
            }

            _cadastroDeCidade.CadastrarCidade(cidade);

            return CreatedAtAction(nameof(ConsultarCidadePorId), new { Id = cidade.Id }, cidade);
        }

        #endregion


        #region Consultar cidades

        /// <summary>
        /// Consultar cidade pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult ConsultarCidadePorId(int id)
        {

            var cidadePorId = _consultaDeCidade.ConsultarCidadePorId(id);

            if (cidadePorId is null)
            {
                return NotFound();
            }

            var cidadeDto = _mapper.Map<CidadeReadDto>(cidadePorId);

            return Ok(cidadeDto);

        }


        /// <summary>
        /// Consultar cidade pelo nome ou estado
        /// </summary>
        /// <param name="cidadesFiltro"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarCidadePeloNomeOuEstado([FromQuery] CidadesRequest cidadesRequest)
        {
            var cidadePorNomeOuEstado = _consultaDeCidade.ConsultarCidadePorNomeOuEstado(cidadesRequest.Nome, cidadesRequest.Estado);

            var cidadeDto = _mapper.Map<CidadeReadDto>(cidadePorNomeOuEstado);

            if (cidadeDto is null)
            {
                return NoContent();
            }

            return Ok(cidadeDto);
        }

        #endregion

    }
}
