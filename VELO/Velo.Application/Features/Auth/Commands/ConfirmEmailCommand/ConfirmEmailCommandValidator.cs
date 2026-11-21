using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Application.Features.Auth.Commands.ConfirmEmailCommand
{
    public class ConfirmEmailCommandValidator:AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.Token).NotEmpty();
        }
    }
}
