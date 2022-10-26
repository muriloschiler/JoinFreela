namespace joinfreela.Application.DTOs.Common
{
    public abstract class UserViewModel: RegisterViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }       
    }
}