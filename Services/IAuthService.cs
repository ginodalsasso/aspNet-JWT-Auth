using aspNet_JWT_Auth.Entities;
using aspNet_JWT_Auth.Models;

namespace aspNet_JWT_Auth.Services
{
    public interface IAuthService
    {
        // Registers a new user and returns the user object
        Task<User?> RegisterAsync(UserDto request);
        // Authenticates the user and returns a JWT token
        Task<TokenResponseDto?> LoginAsync(UserDto request);
        // Logs out the user by invalidating the refresh token
        Task<bool> LogoutAsync(LogoutRequestDto request);
        // Creates a JWT token for the user
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
    }
}
