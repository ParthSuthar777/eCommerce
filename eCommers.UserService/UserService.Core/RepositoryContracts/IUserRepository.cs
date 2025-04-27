﻿using UserService.Core.Entities;

namespace UserService.Core.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string Email, string Password);
    }
}
