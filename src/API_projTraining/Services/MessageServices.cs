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
            listOfMessages.Add(new Message { MessageId = 101, MessageTitle = "FirstMessage", MessageBody = "This is your message", ReceiverEmail = "Alfa@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 102, MessageTitle = "SecondMessage", MessageBody = "This is your message", ReceiverEmail = "Alfa@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 103, MessageTitle = "ThirdMessage", MessageBody = "This is your message", ReceiverEmail = "Alfa@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 101, MessageTitle = "FirstMessage", MessageBody = "This is your message", ReceiverEmail = "Bravo@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 102, MessageTitle = "SecondMessage", MessageBody = "This is your message", ReceiverEmail = "Bravo@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 103, MessageTitle = "ThirdMessage", MessageBody = "This is your message", ReceiverEmail = "Bravo@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 101, MessageTitle = "FirstMessage", MessageBody = "This is your message", ReceiverEmail = "Charlie@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 102, MessageTitle = "SecondMessage", MessageBody = "This is your message", ReceiverEmail = "Charlie@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 103, MessageTitle = "ThirdMessage", MessageBody = "This is your message", ReceiverEmail = "Charlie@testemail.com", SenderEmail = "sender@testmail.com" });
        }

        public List<Message> GetAllMessages()
        {
            return listOfMessages;
        }

        public List<Message> GetListOfMessagesForOneUser(string email)
        {
            List<Message> inbox = new();
            inbox = listOfMessages.FindAll(p => p.ReceiverEmail == email);

            return inbox;
        }
        public void DeleteMessages(string email)
        {
            var messages = listOfMessages.Where(p => p.ReceiverEmail == email).ToList();
            messages.Clear();
        }

        public void AddMessage(Message message)
        {
            var _message = new Message()
            {
                MessageTitle = message.MessageTitle,
                MessageBody = message.MessageBody,
                SenderEmail = message.SenderEmail,
                ReceiverEmail = message.ReceiverEmail
            };
            listOfMessages.Add(_message);
        }
    }
}