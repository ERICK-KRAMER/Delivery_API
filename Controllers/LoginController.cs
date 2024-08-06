using Delivery.Models;
using Delivery.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SignIn([FromBody] Login request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Email and password must be provided.");
            }

            bool login;
            try
            {
                login = await _loginRepository.SignIn(request.Email, request.Password);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }

            return Ok(login);
        }
    }
}
