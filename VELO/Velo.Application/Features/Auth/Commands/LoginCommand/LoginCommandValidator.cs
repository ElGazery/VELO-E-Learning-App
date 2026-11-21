using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Application.Features.Auth.Commands.LoginCommand
{
    public class LoginCommandValidator :AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Password).NotEmpty().MinimumLength(8);
        }
    }
}
