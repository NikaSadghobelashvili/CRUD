using DTO;

namespace Interfaces
{
    public interface IUserRepository
    {
        public int Add(User entity);
        public void Delete(User? entity);
        public User? GetById(int id);
        public int Update(User entity);
        public User? GetByUsername(string username);
        public User? GetByEmail(string email);
    }
}
