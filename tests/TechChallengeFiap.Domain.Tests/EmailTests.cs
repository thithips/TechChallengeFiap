using TechChallengeFiap.Domain.ValueObjects;

namespace TechChallengeFiap.Domain.Tests
{
    public class EmailTests
    {
        [Fact(DisplayName = "Validando se o e-mail informado está com o valor inválido")]
        [Trait("E-mail","Validando e-mail")]
        public void Email_Cadastro_ValorInvalido()
        {
            var email = new Email("thiagoalvescebraspe.org.br");

            Assert.False(email.Validar());
        }

        [Fact(DisplayName = "Validando se o e-mail informado está com o valor válido")]
        [Trait("E-mail", "Validando e-mail")]
        public void Email_Cadastro_ValorValido()
        {
            var email = new Email("thiago.alves@cebraspe.org.br");

            Assert.True(email.Validar());
        }
    }
}
