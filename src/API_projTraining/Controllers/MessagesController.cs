using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/Messages")]
    public class MessagesController : Controller
    {
        public UserServices userservices = new();

        public List<MessageServices> listOfMessages = new();

        [HttpPost("LoginForMessages")]

        //need fixing
        public ActionResult<MessageServices> GetLoginDetailsAndMessage(string email, string password)
        {
            MessageServices messageServices = new();

            var accountDetailsEmail = userservices.GetUserEmail(email);
            var accountDetailsPassword = userservices.GetUserPassword(password);

            if (accountDetailsEmail != null && accountDetailsPassword != null)
            {
                object messagesFromUserInbox = messageServices.GetMessagesFromTheList(password);

                if (messagesFromUserInbox != null)
                {
                    return Ok(messageServices.GetMessagesFromTheList(password));
                }
            }
            else
            {
                return NotFound("Email or password incorrect. Please verify.");
            }
        }
    }
}
