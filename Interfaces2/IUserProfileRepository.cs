using DTO;

namespace Interfaces
{
    public interface IUserProfileRepository
    {
        IEnumerable<UserProfile>? GetAll();
        UserProfile? GetById(int id);
        int Add(UserProfile entity);
        int Update(UserProfile entity);
        void Delete(UserProfile entity);
    }
}
