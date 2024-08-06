using Delivery.Helpers;
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

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            List<User> users = await _userRepository.GetAllUser();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            User? user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid user data.");
            }

            // Hasheia a senha antes de salvar o usuário
            string passwordHash = PasswordHelper.HashPassword(user.Password);
            user.Password = passwordHash; // Armazena o hash da senha na propriedade Password

            // Adiciona o usuário com a senha hasheada
            User createdUser = await _userRepository.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.ID }, createdUser);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> RemoveUser(Guid id)
        {
            bool removedUser = await _userRepository.RemoveUser(id);
            return Ok(removedUser);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<User>> UpdateUser(Guid id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            // Atualize o usuário, mas apenas se a senha for fornecida
            if (!string.IsNullOrEmpty(user.Password))
            {
                string passwordHash = PasswordHelper.HashPassword(user.Password);
                user.Password = passwordHash;
            }

            User updateUser = await _userRepository.UpdateUser(id, user);
            return Ok(updateUser);
        }
    }
}
