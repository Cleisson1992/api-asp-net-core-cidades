using ApiCidades.Domain.Entities;
using ApiCidades.Domain.UserCase.UserCaseCliente.Remove;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Test
{
    public class RepositoryFakeRemoveCliente : IRemoveCliente
    {
        public void RemoverCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
