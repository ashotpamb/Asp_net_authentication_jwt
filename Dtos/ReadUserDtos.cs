using System.ComponentModel.DataAnnotations;

namespace PingChecker.Dtos
{
    public class ReadUserDto
    {

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }

}