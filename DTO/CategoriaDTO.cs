using System.ComponentModel.DataAnnotations;

namespace marketproject.DTO
{
    public class CategoriaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é necessário")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo 3 caracteres")]
        public string Nome { get; set; }
    }
}