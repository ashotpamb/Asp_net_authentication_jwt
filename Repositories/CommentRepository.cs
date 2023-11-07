using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PingChecker.Data;
using PingChecker.Dtos;
using PingChecker.Models;

namespace PingChecker.Repositories
{
    public class CommentRepository : ICommandRepository
    {
        private DataContext _dataContext;

        public CommentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void CreateComment(CommentCreateDto commentCreateDto)
        {
            if (commentCreateDto == null)
            {
                throw new ArgumentNullException();
            }

            var user = _dataContext.Users.SingleOrDefault(u => u.ID == commentCreateDto.UserId);


            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }
            var comment = new Comment
            {
                CommentData = commentCreateDto.CommentData,
                UserId = commentCreateDto.UserId
            };

            _dataContext.Comments.Add(comment);
        }

        public List<Comment> GetCommentsForUser(int userId)
        {
            return _dataContext.Comments.Where(c => c.UserId == userId).Include(u => u.User).ToList();

        }

        public bool SaveChanges()
        {
            return _dataContext.SaveChanges() >= 0;
        }
    }
}