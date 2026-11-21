using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Application.Interfaces.Services.Email
{
    public interface IEmailTemplateService
    {
        public string BuildEmailConfirmationHtml(string confirmationUrl);
        public string BuildPasswordResetHtml(string resetUrl);
    }
}
