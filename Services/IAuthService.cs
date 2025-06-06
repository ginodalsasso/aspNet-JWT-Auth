using aspNet_JWT_Auth.Entities;
using aspNet_JWT_Auth.Models;

namespace aspNet_JWT_Auth.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDto request);

        Task<TokenResponseDto?> LoginAsync(UserDto request);
    }
}
