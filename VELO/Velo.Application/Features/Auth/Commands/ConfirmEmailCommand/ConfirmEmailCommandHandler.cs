using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Common.ApiResponse;
using Velo.Domain.Entities.Identity;
using Velo.Domain.Exceptions;

namespace Velo.Application.Features.Auth.Commands.ConfirmEmailCommand
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<bool>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user is null)
                throw new BadRequestCustomException("User Not found ");
            var result =await _userManager.ConfirmEmailAsync(user, request.Token);
            if(!result.Succeeded)
            {
                throw new BadRequestCustomException("Email confirmation failed");

            }

            return new ApiResponse<bool>(true, "Email Confirm Successfuly", StatusCodes.Status200OK);
                
        }
    }
}
