using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Exceptions;
using TechChallengeFiap.Domain.ValueObjects;

namespace TechChallengeFiap.Domain.Tests
{
    public class ContatoTests
    {
        [Fact]
        public void Contato_Cadastro_ValorInvalido()
        {
            Assert.Throws<DomainException>(() => new Contato(
                 "Thiago",
                 "thiago.alves@cebraspe.org.br",
                 "testando meu numero",
                 new DDD(11, new Guid(), "")));

            Assert.Throws<DomainException>(() => new Contato(
                 "Thiago 102030",
                 "thiago.alves@cebraspe.org.br",
                 "999455499",
                 new DDD(11, new Guid(), "")));
        }

        [Fact]
        public void Contato_Alterar_ValorInvalido()
        {
            Contato contato = new Contato(
                 "Thiago",
                 "thiago.alves@cebraspe.org.br",
                 "999455499",
                 new DDD(11, new Guid(), ""));

            Assert.Throws<DomainException>(() => contato.Alterar(
                 "Thiago 1020",
                 "thiago.alves@cebraspe.org.br",
                 "testando meu super número",
                 new DDD(11, new Guid(), "")));
        }

        [Fact]
        public void Contato_AlterarTelefone_ValorInvalido()
        {
            Contato contato = new Contato(
                 "Thiago",
                 "thiago.alves@cebraspe.org.br",
                 "999455499",
                 new DDD(11, new Guid(), ""));

            Assert.Throws<DomainException>(() => contato.AlterarTelefone(
                new DDD(11, new Guid(), ""),
                "meu numero super alterado"));
        }
        
        [Fact]
        public void Contato_AlterarTelefone_ValorAlterado()
        {
            Contato contato = new Contato(
                 "Thiago",
                 "thiago.alves@cebraspe.org.br",
                 "999455499",
                 new DDD(11, new Guid(), ""));

            contato.AlterarTelefone(new DDD(11, new Guid(), ""), "945459999");

            Assert.Equal("945459999", contato.Telefone);
        }
    }
}