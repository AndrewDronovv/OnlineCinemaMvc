﻿using Microsoft.AspNetCore.Identity;

namespace OnlineCinema.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsMan { get; set; }
    }
}