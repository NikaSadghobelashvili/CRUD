using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;

namespace CrudApplication.Controllers
{
    [ApiController]
    [Route("crud/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IServices<UserProfile> _iUserProfileServices;
        public UserController(IServices<UserProfile> iUserProfileService)
        {
           _iUserProfileServices = iUserProfileService;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok((_iUserProfileServices as UserProfileServices)?.GetUserProfiles(u=>u.UserId==id));
        }
    }
}
