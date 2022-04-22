using System.ComponentModel.DataAnnotations;

namespace marketproject.DTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é necesário")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter pelo menos 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [Phone(ErrorMessage = "Número de telefone inválido")]
        public string Telefone { get; set; }
    }
}