using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/Messages")]
    public class MessageController : ControllerBase
    {
        public MessageServices messageServices = new();
        public UserServices userServices = new();

        [HttpGet("ListMessages")]
        public ActionResult<MessageServices> GetAllMessages()
        {
            return Ok(messageServices.GetAllMessages());
        }

        [HttpGet("ListMessagesForOneUser")]
        public ActionResult<MessageServices> GetListOfMessagesForOneUser(string email, string password)
        {
            if (email == null && password == null)
            {
                return NotFound("Email or password invalid. Please verify.");
            }
            else
            {
                object userLogin = userServices.ValidateLogin(email, password);

                if (userLogin == null)
                {
                    return BadRequest("Email or password invalid. Please verify.");
                }
                else
                {
                    return Ok();
                }
            }

        }

        [HttpDelete("DeleteMessages")]
        public ActionResult<MessageServices> DeleteMessages()
        {
            throw new NotImplementedException();
        }

        [HttpPost("AddMessages")]
        public ActionResult<MessageServices> AddMessages()
        {
            throw new NotImplementedException();
        }
    }
}
