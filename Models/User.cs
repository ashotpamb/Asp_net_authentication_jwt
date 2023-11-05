using System.ComponentModel.DataAnnotations;

namespace PingChecker.Models
{
    public class User
    {
        [Key]

        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public string Token { get; set; }

        public DateTime TokenExpirationTime { get; set; } 
    }
}