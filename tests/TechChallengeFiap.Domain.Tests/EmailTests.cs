using TechChallengeFiap.Domain.ValueObjects;

namespace TechChallengeFiap.Domain.Tests
{
    public class EmailTests
    {
        [Theory(DisplayName = "Validando se o e-mail informado esta com o valor invalido")]
        [Trait("E-mail", "Validando e-mail")]
        [InlineData("thiagoalvescebraspe.org.br")]
        [InlineData("thiagoalvescebraspe@.org.br")]
        public void Email_Cadastro_ValorInvalido(string email)
        {
            var emailResult = new Email(email);

            Assert.False(emailResult.Validar());
        }

        [Fact(DisplayName = "Validando se o e-mail informado esta com o valor valido")]
        [Trait("E-mail", "Validando e-mail")]
        public void Email_Cadastro_ValorValido()
        {
            var email = new Email("thiago.alves@cebraspe.org.br");

            Assert.True(email.Validar());
        }
    }
}
