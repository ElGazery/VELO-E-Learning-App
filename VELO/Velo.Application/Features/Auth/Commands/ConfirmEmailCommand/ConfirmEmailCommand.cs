using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Common.ApiResponse;

namespace Velo.Application.Features.Auth.Commands.ConfirmEmailCommand
{
    public record ConfirmEmailCommand:IRequest<ApiResponse<bool>>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
