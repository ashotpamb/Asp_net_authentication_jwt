using AutoMapper;
using PingChecker.Dtos;
using PingChecker.Models;

namespace PingChecker.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}