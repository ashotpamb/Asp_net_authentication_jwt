using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace PingChecker.Dtos
{
    public class CommentCreateDto
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}