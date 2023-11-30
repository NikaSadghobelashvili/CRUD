using DTO;
using Interfaces;

namespace Repository
{
    public class UserRepository : IUserRepository
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

        public void Delete(User? entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
            }

        }

        public User? GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        }
        public int Update(User entity)
        {
            if (entity != null)
            {
                _dbContext.Users.Update(entity);
                _dbContext.SaveChanges();
                return entity.UserId;
            }
            return -1;
        }

        public User? GetByUsername(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && user.IsActive)
            {
                return user;
            }
            return null;
        }

        public User? GetByEmail(string email)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user != null && user.IsActive)
            {
                return user;
            }
            return null;
        }
    }
}
