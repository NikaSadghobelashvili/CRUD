using DTO;
using Interfaces;
using SharedLibraryProject;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserProfileServices _iUserProfileServices;
        public UserServices(IUnitOfWork unitOfWork, IUserProfileServices userProfileServices)
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
                _iUserProfileServices.Insert(user, userProfile);
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
            var user = _unitOfWork.UserRepository.GetByUsername(username);
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
        public bool VerifyEmail(string email)
        {
            var user = _unitOfWork.UserRepository.GetByEmail(email);
            return user == null;
        }
        public bool VerifyUsername(string username)
        {
            var user = _unitOfWork.UserRepository.GetByUsername(username);
            return user == null;
        }
        public User? GetUserByUsername(string username)
        {
            var user = _unitOfWork.UserRepository.GetByUsername(username);
            return user;
        }
    }
}
