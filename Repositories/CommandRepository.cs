using PingChecker.Data;
using PingChecker.Models;

namespace PingChecker.Repositories
{
    public class CommandRepository : ICommandRepository
    {
        private DataContext _dataContext;

        public CommandRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void CreateComment(Comment comment, int userId)
        {
            if (comment == null && userId == 0)
            {
                throw new ArgumentNullException();
            }
            var user = _dataContext.Users.SingleOrDefault(u => u.ID == userId);
            
            _dataContext.Comments.Add(comment);
        }
    }
}