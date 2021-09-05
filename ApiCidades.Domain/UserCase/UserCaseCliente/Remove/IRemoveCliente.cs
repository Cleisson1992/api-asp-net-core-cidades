using ApiCidades.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Remove
{
    public interface IRemoveCliente
    {
        public void RemoverCliente(Cliente cliente);
    }
}
