namespace aspNet_JWT_Auth.Models
{
    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
