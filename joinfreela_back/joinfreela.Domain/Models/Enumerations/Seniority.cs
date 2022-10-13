using joinfreela.Domain.Models.Base;

namespace joinfreela.Domain.Models.Enumerations
{
    public class Seniority : Enumeration
    {
        public static Seniority Junior = new Seniority(1,nameof(Junior));
        public static Seniority Full = new Seniority(2,nameof(Full));
        public static Seniority Senior = new Seniority(3,nameof(Senior));
        
        public Seniority(int id,string name) => (Id,Name) = (id,name);
        
    }
}