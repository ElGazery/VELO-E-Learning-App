using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
              RuleFor(r => r.Email)
             .NotEmpty()
             .EmailAddress();

            RuleFor(r => r.FullName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100);

           
            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(r => r.ConfirmPassword)
                .NotEmpty()
                .Equal(r => r.Password)
                .WithMessage("Password and Confirm Password do not match.");
        }
    }
}
