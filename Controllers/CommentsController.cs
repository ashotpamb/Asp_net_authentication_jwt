using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PingChecker.Attribtes;
using PingChecker.Dtos;
using PingChecker.Repositories;

namespace PingChecker.Models
{
    [ApiController]
    [Route("")]

    public class CommentsController : Controller
    {
        private readonly ICommandRepository _comentRepository;
        private readonly IMapper _mapper;

        public CommentsController(ICommandRepository commentRepository, IMapper mapper)
        {
            _comentRepository = commentRepository;
            _mapper = mapper;
        }
        [HttpPost("createCommand")]
        public IActionResult CreateComment(CommentCreateDto commentCreateDto)
        {
            _comentRepository.CreateComment(commentCreateDto);
            _comentRepository.SaveChanges();
            return Ok("Comment created successfuly");
        }

        [HttpGet("getCommentsForUser")]
        [AuthorizV1]
        public IActionResult GetCommentsForUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID not found in the token.");
            }

            List<Comment> comments = _comentRepository.GetCommentsForUser(int.Parse(userId));
            var userEmail = comments.FirstOrDefault()?.User.Email;

            var commentReadDtos = _mapper.Map<List<CommentReadDto>>(comments);

            return Ok(new { Message = $"Comment list for USER =>  EMAIL: {userEmail}", Comments = commentReadDtos });
        }
    }
}