using ApiCidades.Domain.Entities;
using ApiCidades.Domain.UserCase.UserCaseCliente.Consulta;
using System;

namespace ApiCidades.Test
{
    public class RepositoryFakeConsultaCliente : IConsultaDeCliente
    {
        public Cliente ConsultarClientePorGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public Cliente ConsultarClientePorId(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente ConsultarClientePorNomeCompleto(string nomeCompleto)
        {
            throw new NotImplementedException();
        }
    }
}
