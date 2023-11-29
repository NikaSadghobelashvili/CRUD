using System;


namespace Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        
        void Save();
    }
}
