using DTO;

namespace Interfaces
{
    public interface IUserServices
    {
        public void RegisterUser(string username, string password, string email, UserProfile userProfile);
        public bool Login(string username, string password);
        public bool VerifyPassword(User user, string password);
        public void DeleteAccount(int userId);
        public void ChangePassword(int userId, string newPassword);
    }
}
