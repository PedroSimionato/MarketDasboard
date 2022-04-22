using System.ComponentModel.DataAnnotations;
using marketproject.Models;

namespace marketproject.DTO
{
    public class EstoqueDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O estoque deve estar ligado a um produto")]
        [StringLength(100, ErrorMessage = "O nome do produto deve ter no máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "O nome do produto deve ter no minimo 3 caracteres")]
        public Produto Produto { get; set; }
        [Required(ErrorMessage = "O estoque deve ter uma quantidade")]
        public float Quantidade { get; set; }
    }
}