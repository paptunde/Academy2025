using Academy2025.Data;
using Academy2025.Dtos;

namespace Academy2025.Services
{
    public interface IAccountService
    {
        Task<User?> LoginAsync(LoginDto loginDto);
    }
}
