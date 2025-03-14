namespace DigiToll.SharedKernel.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Save();

        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();    
    }
}