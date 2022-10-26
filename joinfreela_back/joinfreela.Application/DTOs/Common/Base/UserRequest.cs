namespace joinfreela.Application.DTOs.Common.Base
{
    public abstract class UserRequest: RegisterRequest
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }       
    }
}