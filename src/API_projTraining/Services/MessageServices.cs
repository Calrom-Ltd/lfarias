using API_projTraining.Libraries;
using System.Collections.Generic;

namespace API_projTraining.Services
{
    public class MessageServices : IMessageServices
    {
        public List<Message> listOfMessages = new();
        public MessageServices()
        {
            listOfMessages.Add(new Message { MessageId = 101, MessageTitle = "FirstMessage", MessageBody = "This is your message", ReceiverEmail = "Alfa@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 102, MessageTitle = "SecondMessage", MessageBody = "This is your message", ReceiverEmail = "Alfa@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 103, MessageTitle = "ThirdMessage", MessageBody = "This is your message", ReceiverEmail = "Alfa@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 104, MessageTitle = "FirstMessage", MessageBody = "This is your message", ReceiverEmail = "Bravo@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 105, MessageTitle = "SecondMessage", MessageBody = "This is your message", ReceiverEmail = "Bravo@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 106, MessageTitle = "ThirdMessage", MessageBody = "This is your message", ReceiverEmail = "Bravo@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 107, MessageTitle = "FirstMessage", MessageBody = "This is your message", ReceiverEmail = "Charlie@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 108, MessageTitle = "SecondMessage", MessageBody = "This is your message", ReceiverEmail = "Charlie@testemail.com", SenderEmail = "sender@testmail.com" });
            listOfMessages.Add(new Message { MessageId = 109, MessageTitle = "ThirdMessage", MessageBody = "This is your message", ReceiverEmail = "Charlie@testemail.com", SenderEmail = "sender@testmail.com" });
        }

        public List<Message> GetAllMessages()
        {
            return listOfMessages;
        }

        public List<Message> GetListOfMessagesForOneUser(string email)
        {
            var inbox = listOfMessages.FindAll(p => p.ReceiverEmail == email);
            return inbox;
        }

        //unti test needs reviewing
        public void DeleteMessages(string email) =>
            listOfMessages.FindAll(p => p.ReceiverEmail == email).Clear();


        public void AddMessageToList(Message message)
        {
            var _message = new Message()
            {
                MessageId = message.MessageId,
                MessageTitle = message.MessageTitle,
                MessageBody = message.MessageBody,
                SenderEmail = message.SenderEmail,
                ReceiverEmail = message.ReceiverEmail
            };
            listOfMessages.Add(_message);
        }
    }
}