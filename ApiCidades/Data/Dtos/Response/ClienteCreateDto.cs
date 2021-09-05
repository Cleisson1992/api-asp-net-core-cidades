using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCidades.Data.Dtos
{
    public class ClienteCreateDto
    {
        [Required(ErrorMessage = "O campo Nome Completo é obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo Data De Nascimento é obrigatório")]
        public DateTimeOffset DataDeNascimento { get; set; }

        [Required(ErrorMessage = "O campo Idade é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public string Cidade { get; set; }
    }
}
