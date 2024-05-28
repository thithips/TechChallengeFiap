using System.ComponentModel.DataAnnotations;

namespace TechChallengeFiap.Domain.Models.Contatos
{
    public class ContatoInputModel
    {
        [Required]
        [DeniedValues("string", null, "")]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Telefone { get; set; }
    }
}
