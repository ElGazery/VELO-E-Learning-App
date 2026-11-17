using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Velo.Domain.Entities.Identity;

namespace Velo.Infrastructure.Persistence.AppDbContext
{
    public class VeloDbContext :IdentityDbContext<ApplicationUser, ApplicationRole,Guid>
    {
        public VeloDbContext(DbContextOptions<VeloDbContext>options):base(options)
        { }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


    }
}
