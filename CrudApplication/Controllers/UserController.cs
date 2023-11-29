using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudApplication.Controllers
{
    [ApiController]
    [Route("crud/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserProfileServices _iUserProfileServices;
        public UserController(IUserProfileServices iUserProfileService)
        {
            _iUserProfileServices = iUserProfileService;
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_iUserProfileServices.GetUserProfiles(u => u.UserId == id));
        }
    }
}
