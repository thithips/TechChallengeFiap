using System.ComponentModel.DataAnnotations;

namespace TechChallengeFiap.Domain.Models.Contatos
{
    public class ContatoUpdateInputModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Telefone { get; set; }
    }
}
