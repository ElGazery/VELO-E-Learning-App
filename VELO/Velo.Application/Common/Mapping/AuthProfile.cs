using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Application.Features.Auth.Commands.RegisterCommand;
using Velo.Domain.Entities.Identity;

namespace Velo.Application.Common.Mapping
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterCommand, ApplicationUser>();
        }
    }
}
