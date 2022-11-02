namespace joinfreela.Domain.Interfaces.UnitOfWork
{
    public interface IUnityOfWork
    {
        public Task<bool> CommitChangesAsync(); 
    }
}