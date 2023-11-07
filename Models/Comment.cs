using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PingChecker.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string CommentData { get; set; }
        [Required]
        public int UserId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User User {get;set;}
    }
}