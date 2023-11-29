using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        int Add(TEntity entity);
        int Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
