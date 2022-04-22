using System.ComponentModel.DataAnnotations;
using marketproject.Models;

namespace marketproject.DTO
{
    public class PromocaoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "A promoção deve ter um nome")]
        [StringLength(50, ErrorMessage = "O nome da promoção deve ter no máximo 50 caracteres")]
        [MinLength(3, ErrorMessage = "O nome da promoção deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A promoção deve estar ligada a um produto")]
        public int ProdutoId { get; set; }
        [Required]
        [Range(0,100)]
        public float Porcentagem { get; set; }
    }
}