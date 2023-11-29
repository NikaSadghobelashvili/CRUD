using AutoMapper;
using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services;
using CrudApplication.Models;

namespace CrudApplication.Controllers
{
    [ApiController]
    [Route("crud/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserProfileServices _userProfileServices;
        private readonly IMapper _mapper;
        public UserController(IUserProfileServices iUserProfileService, IMapper mapper)
        {
            _userProfileServices = iUserProfileService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllUserProfiles()
        {
            var profiles = _userProfileServices.GetAllUserProfiles();
            if (profiles == null || !profiles.Any())
            {
                return NotFound("No user profiles found.");
            }
            var mappedProfiles = _mapper.Map<IEnumerable<UserProfileRecord>>(profiles);
            return Ok(mappedProfiles);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserProfile(int id)
        {
            var profile = _userProfileServices.GetUserProfile(id);
            if (profile == null)
            {
                return NotFound("No user profiles found.");
            }
            var mappedProfiles = _mapper.Map<UserProfileRecord>(profile);
            return Ok(mappedProfiles);
        }
    }
}
