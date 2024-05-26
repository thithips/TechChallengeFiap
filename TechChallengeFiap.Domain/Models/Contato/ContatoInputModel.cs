using System.ComponentModel.DataAnnotations;

namespace TechChallengeFiap.Domain.Models.Contatos
{
    public class ContatoInputModel
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Telefone { get; set; }
    }
}
