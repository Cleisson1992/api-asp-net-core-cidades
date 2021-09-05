using ApiCidades.Domain.Entities;
using ApiCidades.Domain.UserCase.UserCaseCidade.Consulta;
using System;

namespace ApiCidades.Test
{
    public class RepositoryFakeConsultaCidade : IConsultaDeCidade
    {
        public Cidade ConsultarCidadePorGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public Cidade ConsultarCidadePorId(int id)
        {
            throw new NotImplementedException();
        }

        public Cidade ConsultarCidadePorNomeOuEstado(string nome = null, string estado = null)
        {
            throw new NotImplementedException();
        }
    }
}
