namespace TechChallengeFiap.Domain.Entities
{
    public class DDD : BaseEntity
    {
        public int NumeroDDD { get; set; }
        public Guid IdEstado { get; set; }
        public Estado? Estado { get; set; }
        public List<Contato>? Contatos { get; set; }

        public DDD() {}
    }
}
