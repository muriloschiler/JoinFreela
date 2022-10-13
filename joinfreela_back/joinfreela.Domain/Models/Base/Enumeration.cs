using System.Reflection;

namespace joinfreela.Domain.Models.Base
{
    public class Enumeration
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
            typeof(T).GetFields(BindingFlags.Public |
                                BindingFlags.Static |
                                BindingFlags.DeclaredOnly)
                     .Select(f => f.GetValue(null))
                     .Cast<T>();

        protected Enumeration() { }
        protected Enumeration(int id, string name) => (Id, Name) = (id, name);
    }
}