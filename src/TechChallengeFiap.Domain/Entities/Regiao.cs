namespace TechChallengeFiap.Domain.Entities;

public class Regiao : BaseEntity
{
    public string Descricao { get; set; }
    public List<Estado>? Estados { get; set; }

    public Regiao() { }

    public Regiao(Guid id, string descricao)
    {
        Id = id;
        DataCriacao = DateTime.Now;
        Descricao = descricao;
    }
}