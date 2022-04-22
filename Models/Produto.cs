namespace marketproject.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Fornecedor Forncedor { get; set; }
        public float PrecoDeCusto { get; set; }
        public float PrecoDeVenda {get; set; }
        public int Medicao { get; set; }
        public bool Status { get; set; }
    }
}