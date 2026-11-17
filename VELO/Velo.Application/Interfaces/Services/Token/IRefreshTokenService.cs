using System;
using System.Collections.Generic;
using System.Text;
using Velo.Domain.Entities.Identity;

namespace Velo.Application.Interfaces.Services.Token
{
    public interface IRefreshTokenService
    {
        public string GenerateToken();
        public string HashToken(string token);
        Task<string> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = default);
        Task RevokeAsync(string rawToken, CancellationToken cancellationToken = default);
    }
}
