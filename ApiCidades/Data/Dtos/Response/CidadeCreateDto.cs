using System.ComponentModel.DataAnnotations;

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
