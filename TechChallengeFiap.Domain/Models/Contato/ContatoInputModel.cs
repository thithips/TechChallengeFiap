using System.ComponentModel.DataAnnotations;

namespace TechChallengeFiap.Domain.Models.Contatos
{
    public class ContatoInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DeniedValues("string", null, "")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public required string Telefone { get; set; }
    }
}
