using TechChallengeFiap.Domain.Exceptions;
using TechChallengeFiap.Domain.Validations;
using TechChallengeFiap.Domain.ValueObjects;

namespace TechChallengeFiap.Domain.Entities;

public class Contato : BaseEntity
{
    public string Nome { get; private set; }
    public Email Email { get; private set; }
    public string Telefone { get; private set; }
    public Guid IdDDD { get; private set; }
    public DDD? DDD { get; private set; }

    public Contato() { }

    public Contato(string nome, string email, string telefone, DDD ddd)
    {
        Nome = nome;
        Telefone = telefone;
        IdDDD = ddd.Id;

        if (string.IsNullOrEmpty(Nome))
            throw new DomainException("Nome em branco! Não é possível criar instância de Cliente");

        if (!AtribuirEmail(email))
            throw new DomainException("E-mail Inválido! Não é possível criar instância de Cliente");

        Validar();
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
        AssertionConcern.ValidarSeDiferente("^[9]{0,1}[0-9]{8}$", telefone, "Valor inválido para o campo telefone.");

        DDD = ddd;
        IdDDD = ddd.Id;
        Telefone = telefone;
    }

    public void Alterar(string nome, string email, string telefone, DDD ddd)
    {
        Nome = nome;
        Telefone = telefone;
        IdDDD = ddd.Id;

        if (Email.Endereco != email && !AtribuirEmail(email))
            throw new DomainException("E-mail Inválido! Não é possível criar instância de Cliente");

        Validar();
    }

    public void Validar()
    {
        AssertionConcern.ValidarSeDiferente("^(?![ ])(?!.*[ ]{2})((?:e|da|do|das|dos|de|d'|D'|la|las|el|los)\\s*?|(?:[A-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð'][^\\s]*\\s*?)(?!.*[ ]$))+$", Nome, "Valor inválido para o campo nome.");
        AssertionConcern.ValidarSeDiferente("^[9]{0,1}[0-9]{8}$", Telefone, "Valor inválido para o campo telefone.");
    }
}