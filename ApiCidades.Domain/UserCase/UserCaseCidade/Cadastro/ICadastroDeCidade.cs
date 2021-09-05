using ApiCidades.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCidade.Cadastro
{
    public interface ICadastroDeCidade
    {
        public void CadastrarCidade(Cidade cidade);
    }
}
