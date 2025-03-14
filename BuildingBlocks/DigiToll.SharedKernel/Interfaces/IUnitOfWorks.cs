namespace DigiToll.SharedKernel.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}