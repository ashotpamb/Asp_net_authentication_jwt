using PingChecker.Models;

namespace PingChecker.Repositories
{
    public interface ICommandRepository
    {
        void CreateComment(Comment comment, int userId);
    }
}