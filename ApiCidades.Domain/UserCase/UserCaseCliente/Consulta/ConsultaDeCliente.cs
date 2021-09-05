using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Consulta
{
    public class ConsultaDeCliente : IConsultaDeCliente
    {
        private readonly IRepository _repo;

        public ConsultaDeCliente(IRepository repo)
        {
            _repo = repo;
        }

        public Cliente ConsultarClientePorId(int id)
        {
            return _repo.Select<Cliente>(id);
        }

        public Cliente ConsultarClientePorGuid(Guid id)
        {
            return _repo.Select<Cliente>(id);
        }

        public Cliente ConsultarClientePorNomeCompleto(string nomeCompleto)
        {
            return _repo.GetQueryable<Cliente>().FirstOrDefault(c => c.NomeCompleto.Equals(nomeCompleto));
        }
    }
}
