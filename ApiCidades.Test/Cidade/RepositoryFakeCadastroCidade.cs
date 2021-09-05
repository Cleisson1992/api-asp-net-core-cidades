using ApiCidades.Domain.Entities;
using ApiCidades.Domain.UserCase.UserCaseCidade.Cadastro;
using System;

namespace ApiCidades.Test
{
    public class RepositoryFakeCadastroCidade : ICadastroDeCidade
    {
        public void CadastrarCidade(Cidade cidade)
        {
            throw new NotImplementedException();
        }
    }
}
