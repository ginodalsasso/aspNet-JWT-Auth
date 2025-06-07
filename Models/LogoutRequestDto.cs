namespace aspNet_JWT_Auth.Models
{
    public class LogoutRequestDto
    {
        public Guid UserId { get; set; }
        public required string RefreshToken { get; set; } // The refresh token to be invalidated
    }
}