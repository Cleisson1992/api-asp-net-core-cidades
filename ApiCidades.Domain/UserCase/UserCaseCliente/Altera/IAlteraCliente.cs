using ApiCidades.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Altera
{
    public interface IAlteraCliente
    {
        public void AlterarCliente(Cliente cliente);
    }
}
