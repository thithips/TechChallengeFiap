namespace TechChallengeFiap.Domain.Entities
{
    public class Contato : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Guid IdDDD { get; set; }
        public DDD? DDD { get; set; }

        public Contato() {}
    }
}
