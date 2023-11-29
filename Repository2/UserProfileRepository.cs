using DTO;
using Interfaces;

namespace Repository
{
    public class UserProfileRepository : IUserProfileRepository
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
            if (entity != null)
            {
                entity.User.IsActive = false;
            }
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _dbContext.UserProfiles.Where(up => up.User.IsActive);
        }

        public UserProfile? GetById(int userId)
        {
            return _dbContext.UserProfiles.FirstOrDefault(up => up.UserId == userId && up.User.IsActive);
        }

        public int Update(UserProfile entity)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.UserId == entity.UserId);
            if (entity != null && user!.IsActive)
            {
                _dbContext.UserProfiles.Update(entity);
                _dbContext.SaveChanges();
                return entity.UserProfileId;
            }
            return -1;
        }
    }
}
