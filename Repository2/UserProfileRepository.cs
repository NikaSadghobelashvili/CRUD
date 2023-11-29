using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserProfileRepository : IRepository<UserProfile>
    {
        private readonly CrudApplicationDbContext _dbContext;
        public UserProfileRepository(CrudApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(UserProfile entity)
        {
            _dbContext.UserProfiles.Add(entity);
            _dbContext.SaveChanges();
            return entity.UserProfileId;
        }

        public void Delete(UserProfile entity)
        {
            _dbContext.UserProfiles.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _dbContext.UserProfiles.Include(profile => profile.User).ToList();
        }

        public UserProfile? GetById(int userId)
        {
            return _dbContext.UserProfiles.FirstOrDefault(up => up.UserId == userId);
        }

        public int Update(UserProfile entity)
        {
            _dbContext.UserProfiles.Update(entity);
            _dbContext.SaveChanges();
            return entity.UserProfileId;
        }
    }
}
