using Academy2025.Data;
using System.IdentityModel.Tokens.Jwt;

namespace Academy2025.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
        
    }
}
