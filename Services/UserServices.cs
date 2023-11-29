using DTO;
using Interfaces;
using Repository;
using SharedLibraryProject;

namespace Services
{
    public class UserServices : IServices<User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServices<UserProfile> _iUserProfileServices;
        public UserServices(IUnitOfWork unitOfWork, IServices<UserProfile> userProfileServices)
        {
            _unitOfWork = unitOfWork;
            _iUserProfileServices = userProfileServices;
        }
        public void RegisterUser(string username, string password, string email, UserProfile userProfile)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var user = new User
                {
                    Username = username,
                    Password = PasswordHashUtility.HashPassword(password),
                    Email = email,
                    IsActive = true,
                };
                (_iUserProfileServices as UserProfileServices)?.Insert(user, userProfile);
                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }
        public bool Login(string username, string password)
        {
            var user = (_unitOfWork.UserRepository as UserRepository)?.GetByUsername(username);
            if (user != null && VerifyPassword(user, password))
            {
                return true;
            }
            return false;
        }
        public bool VerifyPassword(User user, string password)
        {
            return user.Password == PasswordHashUtility.HashPassword(password);
        }
        public void DeleteAccount(int userId)
        {
            _unitOfWork.UserRepository.Delete(_unitOfWork.UserRepository.GetById(userId));
        }
        public void ChangePassword(int userId, string newPassword)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var user = _unitOfWork.UserRepository.GetById(userId);
                user.Password = PasswordHashUtility.HashPassword(newPassword);
                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }
    }
}
