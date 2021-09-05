using ApiCidades.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Cadastro
{
    public interface ICadastroDeCliente
    {
        public void CadastrarCliente(Cliente cliente);
    }
}
