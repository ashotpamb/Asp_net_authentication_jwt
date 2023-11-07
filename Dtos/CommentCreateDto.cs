using System.ComponentModel.DataAnnotations;
using AutoMapper;

namespace PingChecker.Dtos
{
    public class CommentCreateDto
    {
        [Required]
        public string CommentData { get; set; }

        public int UserId { get; set; }

    }
}