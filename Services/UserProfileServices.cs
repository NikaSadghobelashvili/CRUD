using DTO;
using Interfaces;

namespace Services
{
    public class UserProfileServices : IUserProfileServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProfileServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(User user, UserProfile userProfile)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.UserProfileRepository.Add(userProfile);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }
        public void Update(User user, UserProfile userProfile)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                UpdateUser(user);
                UpdateUserProfile(userProfile);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }
        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }
        public void UpdateUserProfile(UserProfile userProfile)
        {
            _unitOfWork.UserProfileRepository.Update(userProfile);
            _unitOfWork.Save();
        }
        public void DeleteUser(int userId)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                var user = _unitOfWork.UserRepository.GetById(userId);
                _unitOfWork.UserRepository.Delete(user);
                _unitOfWork.Save();
                _unitOfWork.CommitTransaction();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<UserProfile>? GetAllUserProfiles() => _unitOfWork.UserProfileRepository.GetAll();
        public IEnumerable<UserProfile>? GetUserProfiles(Func<UserProfile, bool> predicate)
         => _unitOfWork.UserProfileRepository.GetAll()?.Where(predicate);
    }
}
