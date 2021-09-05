using ApiCidades.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCliente.Consulta
{
    public interface IConsultaDeCliente
    {
        public Cliente ConsultarClientePorId(int id);

        public Cliente ConsultarClientePorGuid(Guid id);

        public Cliente ConsultarClientePorNomeCompleto(string nomeCompleto);
    }
}
