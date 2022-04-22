using System.ComponentModel.DataAnnotations;
using marketproject.Models;

namespace marketproject.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O produto deve estar associado a uma categoria")]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "O produto deve estar atrelado ao seu fornecedor")]
        public int FornecedorId { get; set; }
        [Required(ErrorMessage = "O produto deve ter um preço de custo")]
        public float PrecoDeCusto { get; set; }
        [Required(ErrorMessage = "O produto deve ter um preço de venda")]
        public float PrecoDeVenda {get; set; }
        [Required(ErrorMessage = "O produto deve ter um tipo de medicao")]
        [Range(0,2)]
        public int Medicao { get; set; }
    }
}