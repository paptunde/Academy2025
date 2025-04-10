﻿using Academy2025.Data;
using Academy2025.Dtos;
using Academy2025.Repositories;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace Academy2025.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task CreateAsync(UserDto data)
            => _userRepository.CreateAsync(MapToModel(data));

        public Task<bool> DeleteAsync(int id)
            => _userRepository.DeleteAsync(id);

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? MapToDto(user) : null;
        }

        public async Task<UserDto?> UpdateAsync(int id, UserDto data)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user != null)
            {
                user.Name = data.Name;

                await _userRepository.UpdateAsync();
            }

            return user != null ? MapToDto(user) : null;
        }

        private static UserDto MapToDto(User user)=> new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
            Role = user.Role,
            Birth = user.Birth,
        };
        

        private static User MapToModel(UserDto userDto) => new()
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
            HashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password), 
            Role = userDto.Role,
            Birth = userDto.Birth
        };
        
        public async Task<UserDto?> GetUserWithAccessTokenAsync(HttpContext context)
        {
            
                var token = new JwtSecurityTokenHandler().ReadJwtToken(
                    context.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value
                .ToString()
                .Replace("bearer", string.Empty, StringComparison.OrdinalIgnoreCase)
                .Trim());

            var user = await GetByIdAsync(
                Convert.ToInt32(token.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub)!.Value));
            
            return user;
        }
    }
}
