using Delivery.Models;
using Delivery.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
namespace Delivery.Controller.UserController
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("product")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = await _userRepository.GetAllUser();
            return Ok(users);
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            User? user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("product")]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            User createdUser = await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.ID }, createdUser);
        }

        [HttpDelete("product/{id}")]
        public async Task<ActionResult<bool>> RemoveUser(Guid id)
        {
            bool removedUser = await _userRepository.RemoveUser(id);
            return Ok(removedUser);
        }

        [HttpPut("/update{id}")]
        public async Task<ActionResult<User>> UpdateUser(Guid id, [FromBody] User user)
        {
            User updateUser = await _userRepository.UpdateUser(id, user);
            return Ok(updateUser);
        }
    }
}