using ApiCidades.Domain.Entities;
using ApiCidades.Domain.UserCase.UserCaseCliente.Cadastro;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Test
{
    public class RepositoryFakeCadastroCliente : ICadastroDeCliente
    {
        public void CadastrarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
