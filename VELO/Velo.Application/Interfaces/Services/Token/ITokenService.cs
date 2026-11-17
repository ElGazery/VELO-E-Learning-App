using System;
using System.Collections.Generic;
using System.Text;
using Velo.Domain.Entities.Identity;

namespace Velo.Application.Interfaces.Services.Token
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(ApplicationUser user);

    }
}
