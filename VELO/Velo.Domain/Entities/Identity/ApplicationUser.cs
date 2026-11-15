using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Velo.Domain.Entities.Identity
{
    public class ApplicationUser :IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;

        public string? ProfileImageUrl { get; set; }

        public bool NotificationsEnabled { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //public InstructorProfile? InstructorProfile { get; set; }
    }
}
