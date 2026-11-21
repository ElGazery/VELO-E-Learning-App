using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Velo.Application.Common.Settings;
using Velo.Application.Interfaces.Services.Email;

namespace Velo.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string htmlContent, CancellationToken cancellationToken = default)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_emailSettings.SenderName,_emailSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new BodyBuilder() { HtmlBody = htmlContent }.ToMessageBody();

            using var client = new SmtpClient() ;
            try
            {
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls, cancellationToken);
                await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password, cancellationToken);
                await client.SendAsync(email, cancellationToken);
            }finally
            {
                if (client.IsConnected)
                {
                    await client.DisconnectAsync(true,cancellationToken);
                }
            }
            

      
        }
    }
}
