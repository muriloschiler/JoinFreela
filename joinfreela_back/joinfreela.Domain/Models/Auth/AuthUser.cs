namespace joinfreela.Domain.Models.Auth
{
    public class AuthUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}