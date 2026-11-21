using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Common.ApiResponse;
using Velo.Application.Interfaces.Services.Email;
using Velo.Domain.Entities.Identity;
using Velo.Domain.Exceptions;

namespace Velo.Application.Features.Auth.Commands.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResponse<bool>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailConfirmationService _emailConfirmationService;
        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IEmailConfirmationService emailConfirmationService)
        {
            _userManager = userManager;
            _emailConfirmationService = emailConfirmationService;
        }

        public async Task<ApiResponse<bool>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existEmail is not null)
                throw new BadRequestCustomException("Email is already Exist");

            var newUser = new ApplicationUser() { FullName = request.FullName, Email = request.Email };
            
            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                throw new BadRequestCustomException("Unsuccess", errors);
            }
            await _userManager.AddToRoleAsync(newUser, "Student");

            await _emailConfirmationService.SendConfirmationEmailAsync(newUser, cancellationToken);

            return new ApiResponse<bool>(true, "Account registered successfully. Please check your email to confirm your account.", StatusCodes.Status201Created);
            
        }
    }
}
