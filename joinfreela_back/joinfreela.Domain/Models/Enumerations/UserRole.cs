using joinfreela.Domain.Models.Base;

namespace joinfreela.Domain.Models.Enumerations
{
    public class UserRole:Enumeration
    {
        public static UserRole Owner = new UserRole(1,nameof(Owner));

        public static UserRole Freelancer = new UserRole(2,nameof(Freelancer));
        public static UserRole Admin = new UserRole(3,nameof(Admin));
        
        public UserRole(int id,string name) => (Id,Name) = (id,name);
    }
}