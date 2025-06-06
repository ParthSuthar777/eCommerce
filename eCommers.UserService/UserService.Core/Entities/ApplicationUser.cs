﻿namespace UserService.Core.Entities
{
    public class ApplicationUser
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }
    }
}
