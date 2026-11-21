using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Common.ApiResponse;
using Velo.Application.Interfaces.Services.Token;
using Velo.Domain.Entities.Identity;
using Velo.Domain.Exceptions;

namespace Velo.Application.Features.Auth.Commands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<LoginResponseDto>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginCommandHandler(UserManager<ApplicationUser> userManager, ITokenService tokenService, IRefreshTokenService refreshTokenService, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
            _signInManager = signInManager;
        }

        public async Task<ApiResponse<LoginResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                throw new BadRequestCustomException("email or password is not correct");
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);
           
            if (!result.Succeeded)
                throw new BadRequestCustomException("email or password is not correct");
           
                       
            var token = await _tokenService.GenerateTokenAsync(user, cancellationToken);
            var refreshToken = await _refreshTokenService.CreateAsync(user,cancellationToken);

            var dto = new LoginResponseDto()
            {
                Id = user.Id,
                FullName = user.FullName,
                AccessToken = token,
                RefreshToken = refreshToken
            };
            return new ApiResponse<LoginResponseDto>(dto, "Login successfuly", StatusCodes.Status200OK);

        }
    }
}
