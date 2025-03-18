using Academy2025.Data;
using Academy2025.Dtos;
using Academy2025.Repositories;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;

namespace Academy2025.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user is not null && user.Password == loginDto.Password)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public async Task<User?> Login2Async(LoginDto loginDto){
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user != null && BCrypt.Net.BCrypt.Verify(user.HashedPassword, loginDto.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}