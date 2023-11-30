using Microsoft.AspNetCore.Mvc;
using Interfaces;
using CrudApplication.Models;
using AutoMapper;
using DTO;

namespace CrudApplication.Controllers
{
    [ApiController]
    [Route("crud/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IUserProfileServices _userProfileService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthenticationController(IUserProfileServices userProfileService, IUserServices userService, ITokenService tokenService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _userServices = userService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserModel userRegisterModel)
        {
            if (!_userServices.VerifyUsername(userRegisterModel.Username) || !_userServices.VerifyEmail(userRegisterModel.Email))
            {
                return BadRequest("Username or email already exists");
            }

            var user = _mapper.Map<User>(userRegisterModel);
            var userProfile = _mapper.Map<UserProfile>(userRegisterModel);

            _userProfileService.Insert(user, userProfile);

            var token = _tokenService.GenerateToken();
            return Ok(new { Token = token });
        }
        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            if (!_userServices.Login(loginModel.Username, loginModel.Password))
            {
                return Unauthorized();
            }

            var user = _userServices.GetUserByUsername(loginModel.Username);
            var userDto = _mapper.Map<User>(user);

            var token = _tokenService.GenerateToken();
            return Ok(new { Token = token, User = userDto });
        }
    }
}
