using MediatR;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Velo.Application.Common.ApiResponse;

namespace Velo.Application.Features.Auth.Commands.RegisterCommand
{
    public record RegisterCommand() : IRequest<ApiResponse<bool>>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        
    }
}
