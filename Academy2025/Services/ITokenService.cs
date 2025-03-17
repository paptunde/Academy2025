using Academy2025.Data;

namespace Academy2025.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
