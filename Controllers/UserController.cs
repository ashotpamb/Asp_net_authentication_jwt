using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PingChecker.Dtos;
using PingChecker.Models;
using PingChecker.Repositories;
using PingChecker.Services;

namespace PingChecker.Controllers
{
    [ApiController]
    [Route("")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenService _jwtToken;

        public UserController(IMapper mapper, IUserRepository userRepository, JwtTokenService jwtTokenService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _jwtToken = jwtTokenService;
        }
        [HttpPost("signIn")]
        public IActionResult Register(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            try
            {
                _userRepository.RegisterUser(user);
                _userRepository.SaveChanges();
                return Ok(new { Message = "User registred successfully", Token = user.Token });

            }
            catch (Exception ex)
            {

                return Conflict(new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginModel userLoginModel)
        {
            var user = _userRepository.FindUserByEmail(userLoginModel.Email);

            if (user == null)
            {
                return NotFound();
            }
            if (!BCrypt.Net.BCrypt.Verify(userLoginModel.Password, user.Password))
            {
                return BadRequest("Invalid password");
            }

            _userRepository.UpdateUserToken(user);
            _userRepository.SaveChanges();

            var userData = _mapper.Map<User>(user);

            return Ok(new { Token = userData.Token });
        }

    }

}