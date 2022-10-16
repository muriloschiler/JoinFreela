namespace joinfreela.Application.DTOs.Auth
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
    }
}