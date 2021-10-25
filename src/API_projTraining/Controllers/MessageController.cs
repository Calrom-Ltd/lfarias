using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/Messages")]
    public class MessageController : ControllerBase
    {
        public IUserServices _userServices;
        public IMessageServices _messageServices;

        public MessageController(IMessageServices messageServices, IUserServices userServices)
        {
            _messageServices = messageServices;
            _userServices = userServices;
        }

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

        [HttpPost("AddMessageToList")]
        public ActionResult<MessageServices> AddMessage([FromBody] Message message)
        {
            _messageServices.AddMessageToList(message);
            return Ok("Message added to the list.");
        }
    }
}
