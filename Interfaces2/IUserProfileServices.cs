using DTO;

namespace Interfaces
{
    public interface IUserProfileServices
    {
        public void Insert(User user, UserProfile userProfile);
        public void Update(User user, UserProfile userProfile);
        public void UpdateUser(User user);
        public void UpdateUserProfile(UserProfile userProfile);
        public void DeleteUser(int userId);
        public IEnumerable<UserProfile>? GetAllUserProfiles();
        public UserProfile? GetUserProfile(int userId);
    }
}
