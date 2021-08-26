using API_projTraining.Libraries;
using System.Collections.Generic;
using System.Linq;

namespace API_projTraining.Services
{
    public class MessageServices
    {
        public List<Message> listOfMessages = new();
        public MessageServices()
        {            
            listOfMessages.Add(new Message { MessageId = 101, MessageTitle = "FirstMessage", MessageBody = "FirstMessage" });
            listOfMessages.Add(new Message { MessageId = 102, MessageTitle = "SecondMessage", MessageBody = "SecondMessage" });
            listOfMessages.Add(new Message { MessageId = 103, MessageTitle = "ThirdMessage", MessageBody = "ThirdMessage" });
        }
    

        public List<Message> GetAllMessages()
        {
            return listOfMessages;
        }

        //public List<Message> GetListOfMessagesForOneUser(string email)
        //{
        //    var inboxMessages = new List<Message>();

        //    //var listForInboxMessages = new List<Message>();
        //    inboxMessages = listOfMessages.Where(p => p.UserId.Email == email);
           
        //    foreach (var messagecontent in inboxMessages)
        //    {
        //        inboxMessages.Add(messagecontent);
        //    }
        //    if (inboxMessages == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return inboxMessages;
        //    }
        //}
    }
}