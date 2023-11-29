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
            var mappedProfile = _mapper.Map<UserProfileRecord>(profile);
            return Ok(mappedProfile);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUserProfile(int id, [FromBody] UserProfileUpdateModel updatedProfile)
        {
            var existingProfile = _userProfileServices.GetUserProfile(id);
            if (existingProfile == null)
            {
                return NotFound();
            }
            var updatedEntity = _mapper.Map<UserProfile>(updatedProfile);

           
            existingProfile.FirstName = updatedEntity.FirstName;
            existingProfile.LastName = updatedEntity.LastName;
            existingProfile.PersonalNumber = updatedEntity.PersonalNumber;

            _userProfileServices.UpdateUserProfile(existingProfile);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteUserProfile(int id)
        {
            var existingProfile = _userProfileServices.GetUserProfile(id);
            if (existingProfile == null)
            {
                return NotFound();
            }

            _userProfileServices.DeleteUser(existingProfile.UserId);
            return NoContent(); 
        }
    }
}
