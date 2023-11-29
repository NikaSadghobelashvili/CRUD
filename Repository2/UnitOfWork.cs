﻿using Interfaces;
using DTO;
namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudApplicationDbContext _dbContext;

        public UnitOfWork(CrudApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            UserRepository = new UserRepository(_dbContext);
            UserProfileRepository = new UserProfileRepository(_dbContext);
        }

        public IRepository<User> UserRepository { get; }
        public IRepository<UserProfile> UserProfileRepository { get; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}