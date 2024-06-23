using System.Text.RegularExpressions;
using TechChallengeFiap.Domain.Exceptions;

namespace TechChallengeFiap.Domain.Validations
{
    public class AssertionConcern
    {
        /// <summary>
        /// Validação para verificar se os dois objetos informados são iguais
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeIgual(object object1, object object2, string mensagem)
        {
            if (object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação para verificar se os dois objetos informados são diferentes
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeDiferente(object object1, object object2, string mensagem)
        {
            if (!object1.Equals(object2))
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação utilizando um pattern(regex) para comparar se está igual
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="valor"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeDiferente(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(valor))
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de tamanho máximo de string
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="maximo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarTamanho(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de tamanho mínimo e máximo de string
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="maximo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarTamanho(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;
            if (length < minimo || length > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de string vazia
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de objeto nulo
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeNulo(object object1, string mensagem)
        {
            if (object1 == null)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de tamanho mínimo e máximo de um valor double
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="maximo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de tamanho mínimo e máximo de um valor float
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="maximo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de tamanho mínimo e máximo de um valor int
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="maximo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de tamanho mínimo e máximo de um valor long
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="maximo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação de tamanho mínimo e máximo de um valor decimal
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="maximo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação entre dois valores long (se um é menor que o outro)
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação entre dois valores double (se um é menor que o outro)
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação entre dois valores decimal (se um é menor que o outro)
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação entre dois valores int (se um é menor que o outro)
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="minimo"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação se um valor booleano é falso 
        /// </summary>
        /// <param name="boolvalor"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeFalso(bool boolvalor, string mensagem)
        {
            if (!boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }

        /// <summary>
        /// Validação se um valor booleano é verdadeiro
        /// </summary>
        /// <param name="boolvalor"></param>
        /// <param name="mensagem"></param>
        /// <exception cref="DomainException"></exception>
        public static void ValidarSeVerdadeiro(bool boolvalor, string mensagem)
        {
            if (boolvalor)
            {
                throw new DomainException(mensagem);
            }
        }
    }
}
