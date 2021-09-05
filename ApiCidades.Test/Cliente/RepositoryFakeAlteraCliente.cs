using ApiCidades.Domain.Entities;
using ApiCidades.Domain.UserCase.UserCaseCliente.Altera;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Test
{
    public class RepositoryFakeAlteraCliente : IAlteraCliente
    {
        public void AlterarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
