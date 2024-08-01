using Microsoft.AspNetCore.Mvc;
using Delivery.Model.User;

namespace Delivery.Controller.UserController
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok("ok");
        }
    }
}