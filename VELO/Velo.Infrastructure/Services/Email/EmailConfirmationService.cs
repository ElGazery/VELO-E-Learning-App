using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Common.Settings;
using Velo.Application.Interfaces.Services.Email;
using Velo.Domain.Entities.Identity;

namespace Velo.Infrastructure.Services.Email
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;
        public readonly FrontEndSettings _frontEndSettings;

        public EmailConfirmationService(UserManager<ApplicationUser> userManager, IEmailService emailService, IEmailTemplateService emailTemplateService,IOptions<FrontEndSettings> options)
        {
            _userManager = userManager;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _frontEndSettings = options.Value;
        }
        public async Task SendConfirmationEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var baseUrl = _frontEndSettings.URL.TrimEnd('/');
            var confirmUrl = $"{baseUrl}/confirm-email\" + $\"?userId={Uri.EscapeDataString(user.Id.ToString())}\" +$\"&token={Uri.EscapeDataString(token)}";
            var emailBody = _emailTemplateService.BuildEmailConfirmationHtml(confirmUrl);
            await _emailService.SendEmailAsync(user.Email, "Confirm Email - Levo", emailBody, cancellationToken);

        }
    }
}
