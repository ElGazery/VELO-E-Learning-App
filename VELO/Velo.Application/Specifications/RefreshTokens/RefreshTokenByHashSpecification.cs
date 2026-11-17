using System;
using System.Collections.Generic;
using System.Text;
using Velo.Domain.Entities.Identity;

namespace Velo.Application.Specifications.RefreshTokens
{
    public class RefreshTokenByHashSpecification :BaseSpecification<RefreshToken>
    {
        public RefreshTokenByHashSpecification(string tokenHash)
        {
            Criteria = token => token.TokenHash == tokenHash;
            AddInclude(e => e.User);
        }
    }
}
