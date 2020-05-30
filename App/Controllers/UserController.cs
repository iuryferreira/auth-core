using System.Threading.Tasks;
using App.Models;
using App.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController (IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get ([FromRoute] int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post ([FromBody] User u)
        {
            var userCreated = await repository.Save(u);
            return CreatedAtAction("Get", new { id = userCreated.Id }, userCreated);
        }

    }
}