using System.Net;
using System.Net.Mail;
using TechChallengeFiap.Core;

namespace TechChallengeFiap.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(EmailModel model)
        {
            int.TryParse(_configuration["Smtp:Port"], out int port);

            MailMessage message = new MailMessage();
            var smtpClient = new SmtpClient(_configuration["Smtp:Host"], port);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_configuration["Smtp:User"], _configuration["Smtp:Password"]);
            message.From = new MailAddress(_configuration["Smtp:User"]);
            message.Body = model.Message;
            message.Subject = model.Subject;
            message.IsBodyHtml = true;
            message.To.Add(model.Email);
            smtpClient.Send(message);
        }
    }
}
