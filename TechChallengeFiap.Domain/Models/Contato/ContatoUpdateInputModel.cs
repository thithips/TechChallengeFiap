using System.ComponentModel.DataAnnotations;

namespace TechChallengeFiap.Domain.Models.Contatos
{
    public class ContatoUpdateInputModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [DeniedValues(null, "", "string")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Length(10, 11, ErrorMessage = "O campo {0} deve ter entre 10 e 11 caracteres!")]
        public required string Telefone { get; set; }
    }
}
