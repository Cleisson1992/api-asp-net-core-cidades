using ApiCidades.Data;
using ApiCidades.Data.Dtos;
using ApiCidades.Filtro;
using ApiCidades.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace ApiCidades.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadesController : ControllerBase
    {
        #region Utilização do contexto(Bd) e mapeamento da Api

        private ApiCidadeContext _context;
        private readonly ILogger<CidadesController> _logger;
        private IMapper _mapper;

        public CidadesController(ApiCidadeContext context, ILogger<CidadesController> logger, IMapper mapper)
        {
            _logger = logger ??
                  throw new ArgumentNullException(nameof(logger));

            _context = context ??
                throw new ArgumentNullException(nameof(context));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        #endregion


        #region Cadastrar cidade

        [HttpPost]
        public IActionResult CadastrarCidade([FromBody] CidadeCreateDto cidadeDto)
        {
            Cidade cidade = _mapper.Map<Cidade>(cidadeDto);

            _context.Cidades.Add(cidade);
            _context.SaveChanges();
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
            Cidade cidade = _context.Cidades.FirstOrDefault(cidade => cidade.Id == id);

            if (cidade != null)
            {
                CidadeReadDto clienteDto = _mapper.Map<CidadeReadDto>(cidade);
            }

            return NotFound();
        }


        /// <summary>
        /// Consultar cidade pelo nome ou estado
        /// </summary>
        /// <param name="cidadesFiltro"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ConsultarCidadePeloNomeOuEstado([FromQuery] CidadesFiltro cidadesFiltro)
        {
            Cidade cidadePeloNome = _context.Cidades.FirstOrDefault(cidade => cidade.Nome == cidadesFiltro.Nome);
            Cidade cidadeEstado = _context.Cidades.FirstOrDefault(cidade => cidade.Estado == cidadesFiltro.Estado);

            if (cidadePeloNome != null)
            {
                CidadeReadDto clienteDto = _mapper.Map<CidadeReadDto>(cidadePeloNome);

                return Ok(clienteDto);
            }

            if (cidadeEstado != null)
            {
                CidadeReadDto clienteDto = _mapper.Map<CidadeReadDto>(cidadeEstado);
                return Ok(clienteDto);
            }

            else if (_context.Cidades != null)
            {
                return Ok(_context.Cidades);
            }
                
            return NotFound();
        }

        #endregion

    }
}
