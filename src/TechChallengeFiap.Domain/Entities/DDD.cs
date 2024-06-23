namespace TechChallengeFiap.Domain.Entities
{
    public class DDD : BaseEntity
    {
        public int NumeroDDD { get; set; }
        public Guid IdEstado { get; set; }
        public string Regioes { get; set; }
        public Estado? Estado { get; set; }
        public List<Contato>? Contatos { get; set; }

        public DDD() {}

        public DDD(int ddd, Guid idEstado, string regioes)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;
            NumeroDDD = ddd;
            IdEstado = idEstado;
            Regioes = regioes;
        }
    }
}
