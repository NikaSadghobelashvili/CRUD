using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace CrudApplication.Controllers
{
    [ApiController]
    [Route("crud/[controller]")]
    public class UserController: ControllerBase
    {
        public UserController()
        {
           
        }
    }
}
