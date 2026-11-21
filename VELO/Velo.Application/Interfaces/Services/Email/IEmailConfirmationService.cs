using System;
using System.Collections.Generic;
using System.Text;
using Velo.Domain.Entities.Identity;

namespace Velo.Application.Interfaces.Services.Email
{
    public interface IEmailConfirmationService
    {
        public  Task SendConfirmationEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default);
    }
}
