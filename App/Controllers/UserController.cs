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

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get ([FromServices] IUserRepository repository, [FromRoute] int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post ([FromServices] IUserRepository repository, [FromBody] User u)
        {
            var userCreated = await repository.Save(u);
            return CreatedAtAction("Get", new { id = userCreated.Id }, userCreated);
        }

    }
}