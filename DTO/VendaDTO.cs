using System;
using System.ComponentModel.DataAnnotations;

namespace marketproject.DTO
{
    public class VendaDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "A venda deve ter uma data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "A venda deve ter um valor total")]
        public double Total { get; set; }
        [Required(ErrorMessage = "A venda deve ser paga")]
        public double Pago { get; set; }
        public double Troco { get; set; }
    }
}