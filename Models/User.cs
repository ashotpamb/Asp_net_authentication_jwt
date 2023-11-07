using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PingChecker.Models
{
    [Index(nameof(Email), IsUnique =true)]
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public string Token { get; set; }

        public DateTime TokenExpirationTime { get; set; }

        public List<Comment> Comments {get;set;}
    }
}