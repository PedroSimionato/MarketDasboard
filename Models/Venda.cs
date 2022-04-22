using System;

namespace marketproject.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Total { get; set; }
        public double Pago { get; set; }
        public double Troco { get; set; }
    }
}