using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        public IUserServices _userservices = new UserServices();

        public UserController(IUserServices userServices)
        {
            _userservices = userServices;
        }

        [HttpGet("UsersList")]
        public ActionResult GetAllUsers()
        {
            return Ok(_userservices.GetAllUsers());
        }

        [HttpGet("GetUserByEmail")]
        public ActionResult GetUserByEmail(string email)
        {
            return Ok(_userservices.GetUserByEmail(email));
        }

        [HttpPost("Login")]
        public ActionResult<User> Login(string email, string password)
        {
            object userLogin = _userservices.ValidateLogin(email, password);

            if (userLogin == null)
            {
                return BadRequest("Email or password invalid. Please verify.");
            }
            else
            {
                return Ok("Login successful.");
            }
        }
    }
}