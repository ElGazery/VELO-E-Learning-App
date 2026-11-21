using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Application.Features.Auth.Commands.LoginCommand
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
