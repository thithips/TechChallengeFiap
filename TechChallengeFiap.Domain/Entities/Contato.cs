using TechChallengeFiap.Domain.ValueObjects;

namespace TechChallengeFiap.Domain.Entities
{
    public class Contato : BaseEntity
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public string Telefone { get; private set; }
        public Guid IdDDD { get; private set; }
        public DDD? DDD { get; private set; }

        public Contato() {}

        public Contato(string nome, string email, string telefone, DDD ddd)
        {
            Nome = nome;
            Telefone = telefone;
            IdDDD = ddd.Id;

            if (string.IsNullOrEmpty(Nome))
                throw new Exception("Nome em branco! Não é possível criar instância de Cliente");

            if (!AtribuirEmail(email))
                throw new Exception("E-mail Inválido! Não é possível criar instância de Cliente");
        }

        public bool AtribuirEmail(string enderecoEmail)
        {
            var email = new Email(enderecoEmail);
            if (!email.Validar()) return false;
            Email = email;
            return true;
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
            Telefone = telefone;
            IdDDD = ddd.Id;

            if(Email.Endereco != email && !AtribuirEmail(email))
                throw new Exception("E-mail Inválido! Não é possível criar instância de Cliente");
        }
    }
}
