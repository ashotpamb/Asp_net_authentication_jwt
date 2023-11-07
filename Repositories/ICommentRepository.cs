using PingChecker.Dtos;
using PingChecker.Models;

namespace PingChecker.Repositories
{
    public interface ICommandRepository
    {
        void CreateComment(CommentCreateDto commentCreateDto);

        List<Comment> GetCommentsForUser(int userId);
        bool SaveChanges();
    }
}