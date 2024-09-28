using TechChallengeFiap.Core;

namespace TechChallengeFiap.Email.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailModel model);
    }
}