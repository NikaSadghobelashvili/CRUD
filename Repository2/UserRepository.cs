using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository: IRepository<User>
    {
        private readonly CrudApplicationDbContext _dbContext;
        public UserRepository(CrudApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return entity.UserId;
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User? GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        }
        public int Update(User entity)
        {
            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();
            return entity.UserId;
        }
    }
}
