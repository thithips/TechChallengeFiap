namespace TechChallengeFiap.Domain.Entities
{
    public class Estado : BaseEntity
    {
        public string Uf { get; set; }
        public string Descricao { get; set; }
        public Guid IdRegiao { get; set; }
        public Regiao? Regiao { get; set; }
        public List<DDD>? DDDs { get; set; }

        public Estado(Guid id, string descricao, Guid idRegiao, string uf)
        {
            Id = id;
            Descricao = descricao;
            IdRegiao = idRegiao;
            Uf = uf;
            DataCriacao = DateTime.Now;
        }

        public Estado() {}
    }
}
