using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace API_projTraining.Services
{
    public class MessageServices : Messages
    {
        public UserServices userservices = new();

        public readonly List<Messages> listOfMessages = new();

        public MessageServices()
        {
            listOfMessages.Add(new Messages { UserNameId = 01, MsgId = 101, Subject = "FirstMessage", MessageBody = "FirstMessage" });
            listOfMessages.Add(new Messages { UserNameId = 02, MsgId = 102, Subject = "SecondMessage", MessageBody = "SecondMessage" });
            listOfMessages.Add(new Messages { UserNameId = 03, MsgId = 103, Subject = "ThirdMessage", MessageBody = "ThirdMessage" });
        }

        public List<Messages> GetAllMessages()
        {
            return listOfMessages;
        }

        //public List<Messages> GetMessagesFromTheList(string email, string password, int messageuserid)
        public List<Messages> GetMessagesFromTheList(string password)
        {
            var inboxMessages = new List<Messages>();

            //need fixing
            var listForInboxMessages = listOfMessages.Where(p => p.UserNameId == password);

            foreach (var messagecontent in listForInboxMessages)
            {
                inboxMessages.Add(messagecontent);
            }
            return inboxMessages;
        }
    }
}