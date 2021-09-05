using ApiCidades.Domain.Entities;
using ApiCidades.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCidades.Domain.UserCase.UserCaseCidade.Cadastro
{
    public class CadastroDeCidade : ICadastroDeCidade
    {
        private readonly IRepository _repo;

        public CadastroDeCidade(IRepository repo)
        {
            _repo = repo;
        }

        public void CadastrarCidade(Cidade cidade)
        {
             _repo.Insert(cidade);
        }
    }
}
