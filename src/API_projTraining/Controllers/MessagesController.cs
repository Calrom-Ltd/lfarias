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

        //public void GetAllMessages()
        //{
        //    List<Messages> calledListOfMessages = messageservices.GetAllMessages();
        //}

        [HttpPost("LoginForMessages")]
        public ActionResult<MessageServices> GetMessageToList(string email, string password, int useridentificationformessages)
        {
            MessageServices messageServices = new();
            object accountDetailsEmail = null;
            object accountDetailsPassword = null;

            if (email != null && password != null)
            {
                accountDetailsEmail = userservices.GetAllUsers().Find(z => z.Email == email);
                accountDetailsPassword = userservices.GetAllUsers().Find(z => z.Password == password);

                if (accountDetailsEmail != null && accountDetailsPassword != null)
                {
                    var TotalNumberOfMessages = messageServices.listOfMessages.Count;

                    if (useridentificationformessages <= TotalNumberOfMessages)
                    {
                        return Ok(messageServices.GetMessageFromList(email, password, useridentificationformessages));
                    }
                }

                else if (accountDetailsEmail == null)
                {
                    NotFound("Incorrect email address. Please verify.");
                }

                else if (accountDetailsPassword == null)
                {
                    NotFound("Incorrect password. Please verify.");
                }
            }
            else
            {
                return NotFound("Email or password incorrect. Please verify.");
            }
        }
    }
}
