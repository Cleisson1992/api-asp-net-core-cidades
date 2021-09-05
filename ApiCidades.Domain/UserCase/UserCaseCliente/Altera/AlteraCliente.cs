using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using ApiCidades.Domain.UserCase.UserCaseCliente.Altera;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Altera
{
    public class AlteraCliente : IAlteraCliente
    {
        private readonly IRepository _repo;

        public AlteraCliente(IRepository repo)
        {
            _repo = repo;
        }

        public void AlterarCliente(Cliente cliente)
        {
            _repo.Update(cliente);
        }
    }
}
