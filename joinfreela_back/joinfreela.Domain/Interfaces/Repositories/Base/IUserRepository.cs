using joinfreela.Domain.Classes.Base;

namespace joinfreela.Domain.Interfaces.Repositories.Base
{
    public interface IUserRepository<T>:IBaseRepository<T>
    where T:User
    {}
}