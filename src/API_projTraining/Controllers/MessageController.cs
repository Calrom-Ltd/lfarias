using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/Messages")]
    public class MessageController : ControllerBase
    {
        public MessageServices _messageServices = new();
        public UserServices _userServices = new();

        [HttpGet("ListMessages")]
        public ActionResult<MessageServices> GetAllMessages()
        {
            return Ok(_messageServices.GetAllMessages());
        }

        [HttpGet("ListMessagesForOneUser")]
        public ActionResult<MessageServices> GetListOfMessagesForOneUser(string email, string password)
        {
            var userLogin = _userServices.ValidateLogin(email, password);

            if (userLogin == null)
            {
                return NotFound("Email or password invalid. Please verify.");
            }
            else
            {
                return Ok(_messageServices.GetListOfMessagesForOneUser(email));
            }
        }

        //unit test needs reviewing
        [HttpDelete("DeleteMessages")]
        public ActionResult DeleteMessages(string email, string password)
        {
            var userLogin = _userServices.ValidateLogin(email, password);

            if (userLogin == null)
            {
                return BadRequest("Email or password invalid. Please verify.");
            }
            else
            {
                _messageServices.DeleteMessages(email);
                return Ok("Messages deleted");
            }
        }

        [HttpPost("AddMessage")]
        public ActionResult<MessageServices> AddMessage([FromBody] Message message)
        {
            _messageServices.AddMessage(message);
            return Ok("Messages added to the list.");
        }
    }
}
