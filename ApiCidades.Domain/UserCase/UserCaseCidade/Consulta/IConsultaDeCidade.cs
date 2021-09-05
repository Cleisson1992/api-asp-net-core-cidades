using ApiCidades.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCidade.Consulta
{
    public interface IConsultaDeCidade
    {
        public Cidade ConsultarCidadePorId(int id);

        public Cidade ConsultarCidadePorGuid(Guid id);

        public Cidade ConsultarCidadePorNomeOuEstado(string nome = null, string estado = null);
    }
}
