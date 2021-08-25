using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        public UserServices _userservices;
        public MessageServices _messageservices;
        public UserController(UserServices userservices, MessageServices messageservices)
        {
            _userservices = userservices;
            _messageservices = messageservices;
        }

        [HttpGet("UsersList")]
        
        public IActionResult GetAllUsers()
        {
            return Ok(_userservices.GetAllUsers());
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var TotalNumberOfUsers = _userservices.listOfUsers.Count;
            if (id <= TotalNumberOfUsers)
            {
                return Ok(_userservices.GetUserById(id));
            }
            else
            {
                return NotFound("ID not found");
            }
        }

        [HttpPost("LoginForMessages")]
        public ActionResult<MessageServices> GetLoginDetailsAndMessage(string email, string password)
        {
            var accountDetailsEmail = _userservices.GetUserEmail(email);
            var accountDetailsPassword = _userservices.GetUserPassword(password);

            if (accountDetailsEmail != null && accountDetailsPassword != null)
            {

                object messagesFromUserInbox = _messageservices.GetMessagesFromTheList(email);

                if (messagesFromUserInbox != null)
                {
                    return Ok($"Hi {accountDetailsEmail}, this is your list of messages: {messagesFromUserInbox}");
                }
            }
            else
            {
                return NotFound($"Email or password incorrect. Please verify.");
            }
        }
    }
}