namespace joinfreela.Application.DTOs.Common.Base
{
    public class UserResponse : RegisterResponse
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public EnumerationViewModel UserRole { get; set; }  
    }
}