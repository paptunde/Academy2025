﻿using Academy2025.Dtos;
using System.IdentityModel.Tokens.Jwt;

namespace Academy2025.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserDto data);
        Task<bool> DeleteAsync(int id);
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> UpdateAsync(int id, UserDto data);
        Task<UserDto?> GetUserWithAccessTokenAsync(HttpContext context);
    }

}