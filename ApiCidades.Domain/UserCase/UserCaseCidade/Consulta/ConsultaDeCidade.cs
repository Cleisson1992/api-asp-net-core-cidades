using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCidade.Consulta
{
    public class ConsultaDeCidade : IConsultaDeCidade
    {
        private readonly IRepository _repo;

        public ConsultaDeCidade(IRepository repo)
        {
            _repo = repo;
        }

        public Cidade ConsultarCidadePorId(int id)
        {
            return _repo.Select<Cidade>(id);
        }

        public Cidade ConsultarCidadePorGuid(Guid id)
        {
            return _repo.Select<Cidade>(id);
        }

        public Cidade ConsultarCidadePorNomeOuEstado(string nome = null, string estado = null)
        {
            if (string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(estado))
            {
                return null;
            }             

            else if(!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(estado))
            {
                return _repo.GetQueryable<Cidade>().FirstOrDefault(c => c.Nome.Equals(nome) && c.Estado.Equals(estado));
            }               

            return _repo.GetQueryable<Cidade>().FirstOrDefault(c => c.Nome.Equals(nome) || c.Estado.Equals(estado));       
        }
    }
}
