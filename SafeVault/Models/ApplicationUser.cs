﻿using Microsoft.AspNetCore.Identity;

namespace SafeVault.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
    }
}
