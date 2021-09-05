using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Remove
{
    public class RemoveCliente : IRemoveCliente
    {
        private readonly IRepository _repo;

        public RemoveCliente(IRepository repo)
        {
            _repo = repo;
        }

        public void RemoverCliente(Cliente cliente)
        {
            _repo.Delete(cliente);
        }
    }
}
