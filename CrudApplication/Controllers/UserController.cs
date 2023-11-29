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
        private readonly IRepository<User> _repository;
        public UserController(IRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id) => Ok(_repository.GetById(id));
    }
}
