using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCidades.Data.Dtos
{
    public class CidadeCreateDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da cidade não pode ter mais que 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public string Estado { get; set; }
    }
}
