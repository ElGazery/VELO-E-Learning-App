using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Velo.Application.Common.ApiResponse;

namespace Velo.Application.Features.Auth.Commands.LoginCommand
{
    public record LoginCommand :IRequest<ApiResponse<LoginResponseDto>>
    {
       
        public string Email { get; set; } 
        public string Password { get; set; } 

    }
}
