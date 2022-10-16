using joinfreela.Domain.Models.Enumerations;

namespace joinfreela.Domain.Classes.Base{
    public abstract class User: Register
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
    }
}