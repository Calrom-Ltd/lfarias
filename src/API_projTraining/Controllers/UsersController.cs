using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/User")]
    //[Consumes("application/json")]
    public class ActionResult : ControllerBase
    {
        [HttpGet("OneUser")]
        public ActionResult<User> FindUser(int id)
        {
            UserServices myuserservices = new();
            if (id > 0 & id < 11)
            {
                return myuserservices.FindUser(id);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("AllUsers")]
        public List<User> FindAllUsers()
        {
            UserServices myuserservices = new();
            return myuserservices.FindAllUsers();
        }

        [HttpGet("SomeUsers")]
        //need to sort a way to fetch and return random users from the array
        public ActionResult<List<User>> FindSomeUsers(int numberOfUsers)
        {
            UserServices myuserservices = new();
            if (numberOfUsers > 0 && numberOfUsers < 11)
            {
                return myuserservices.FindSomeUsers(numberOfUsers);
            }
            else
            {
                return NotFound();
            }
        }
    }
}