using Microsoft.AspNetCore.Mvc;
using System.Net;
using Users.API.Entities;
using Users.API.Repositories;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository repository, ILogger<UserController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var Users = await _repository.GetAll();
            return Ok(Users);
        }

        [HttpGet("{id:length(24)}", Name = "Get")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> Get(string id)
        {
            var Users = await _repository.Get(id);
            if (Users == null)
            {
                _logger.LogError($"User with id: {id}, not found.");
                return NotFound();
            }
            return Ok(Users);
        }

        [Route("[action]/{email}", Name = "GetByEmail")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetByEmail(string email)
        {
            var Users = await _repository.GetByEmail(email);
            return Ok(Users);
        }

        [Route("[action]/{name}", Name = "GetByName")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetByName(string name)
        {
            var Users = await _repository.GetByName(name);
            return Ok(Users);
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> Create([FromBody] User User)
        {
            await _repository.Create(User);

            return CreatedAtRoute("Get", new { id = User.Id }, User);
        }

        [HttpPut]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] User User)
        {
            return Ok(await _repository.Update(User));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
