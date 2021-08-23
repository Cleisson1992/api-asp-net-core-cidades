using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCidades.Data.Dtos
{
    public class CidadeReadDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da cidade não pode ter mais que 60 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        [StringLength(2, ErrorMessage = "A sigla do estado não pode conter mais que dois caracteres")]
        public string Estado { get; set; }
    }
}
