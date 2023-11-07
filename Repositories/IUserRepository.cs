using PingChecker.Models;

namespace PingChecker.Repositories
{
    public interface IUserRepository 
    {
        IEnumerable<User> GetUsers();
        bool SaveChanges();
        User GetUser(long ID);
        void RegisterUser(User user);
        User FindUserByEmail(string email);
        void UpdateUserToken(User user);
        User GetUserByUsername(string userName);
        bool CheckUserExisting(string email);
                
    }
}