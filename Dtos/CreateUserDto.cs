using System.ComponentModel.DataAnnotations;

namespace PingChecker.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(8)]
        public string Password { get; set; }
    }

}