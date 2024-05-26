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

        public Contato(string nome, string email, string telefone, DDD ddd)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            IdDDD = ddd.Id;
        }

        public void AlterarTelefone(DDD ddd, string telefone)
        {
            DDD = ddd;
            IdDDD = ddd.Id;
            Telefone = telefone;
        }

        public void Alterar(string nome, string email, string telefone, DDD ddd)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            IdDDD = ddd.Id;
        }
    }
}
