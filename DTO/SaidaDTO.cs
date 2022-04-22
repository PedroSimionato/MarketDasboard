using System;
using System.ComponentModel.DataAnnotations;
using marketproject.Models;

namespace marketproject.DTO
{
    public class SaidaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "A saida deve ter ao menos um produto")]
        [StringLength(100, ErrorMessage = "O produto deve ter no máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "O produto deve ter pelo menos 3 caracteres")]
        public Produto Produto { get; set; }
        [Required(ErrorMessage = "A saida deve ter um valor de venda")]
        public float ValorDaVenda { get; set; }
        [Required(ErrorMessage = "A saída deve ter uma data")]
        public DateTime Data { get; set; }
    }
}