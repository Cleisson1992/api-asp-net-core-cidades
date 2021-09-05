using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Cadastro
{
    public class CadastroDeCliente : ICadastroDeCliente
    {
        private readonly IRepository _repo;

        public CadastroDeCliente(IRepository repo)
        {
            _repo = repo;
        }

        public void CadastrarCliente(Cliente cliente)
        {
            _repo.Insert(cliente);
        }
    }
}
