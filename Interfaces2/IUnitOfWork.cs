namespace Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
