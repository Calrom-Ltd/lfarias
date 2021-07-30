using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : Controller
    {
        public List<User> listOfUsers = new();
    
        [HttpGet("UsersList")]
        public ActionResult<List<User>> GetAllUsers()
        {
            UserServices userServices = new();
            return Ok(userServices.GetAllUsers());
        }

        [HttpGet("GetUserById")]
        public ActionResult<UserServices> GetUserById(int id)
        {
            UserServices userServices = new();
            var TotalNumberOfUsers = userServices.listOfUsers.Count;
            if (id <= TotalNumberOfUsers)
            {
                return Ok(userServices.GetUserById(id));
            }
            else
            {
                return NotFound("ID not found");
            }
        }
    }
}