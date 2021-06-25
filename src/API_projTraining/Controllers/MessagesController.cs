using API_projTraining.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_projTraining.Controllers
{
    [ApiController]
    [Route("api/Messages")]
    public class MessagesController : ControllerBase
    {
        [HttpGet("OneMessage")]
        public ActionResult<Messages> FindMessage(int mId)
        {
            MessageServices mymessages = new();
            if (mId > 0 & mId < 11)
            {
                return mymessages.FindMessage(mId);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("AllMessages")]
        public List<Messages> FindAllMessages()
        {
            MessageServices mymessageservices = new();
            return mymessageservices.FindAllMessages();
        }

        [HttpGet("SomeMessages")]
        //need to sort a way to fetch and return random users from the array
        public ActionResult<List<Messages>> FindSomeMessages(int numberOfMessages)
        {
            MessageServices mymessageservices = new();
            if (numberOfMessages > 0 & numberOfMessages < 11)
            {
                return mymessageservices.FindSomeMessages(numberOfMessages);
            }
            else
            {
                return NotFound();
            }
        }

        ////// POST api/<MessagesController>
        //[HttpPost]
        //public void PostMessage([FromBody] Messages msg)
        //{


        //}

        //// PUT api/<MessagesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MessagesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
