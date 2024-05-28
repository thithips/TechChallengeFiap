﻿using TechChallengeFiap.Domain.Entities;
using TechChallengeFiap.Domain.Exceptions;
using TechChallengeFiap.Domain.ValueObjects;

namespace TechChallengeFiap.Domain.Tests
{
    public class EmailTests
    {
        [Fact]
        public void Email_Cadastro_ValorInvalido()
        {
            var email = new Email("thiagoalvescebraspe.org.br");

            Assert.False(email.Validar());
        }

        [Fact]
        public void Email_Cadastro_ValorValido()
        {
            var email = new Email("thiago.alves@cebraspe.org.br");

            Assert.True(email.Validar());
        }
    }
}