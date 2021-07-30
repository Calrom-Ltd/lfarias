using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace API_projTraining.Services
{
    public class MessageServices : Messages
    {

        public UserServices userservices = new();

        //public void GetAllUsers()
        //{
        //    List<User> calledListOfUsers = userservices.GetAllUsers();
        //}

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

        public List<Messages> GetMessageFromList(string email, string password, int messageuserid)
        {
            var inboxMessages = new List<Messages>();

            object accountMessageDetailsEmail = null;
            object accountMessageDetailsPassword = null;
            object accountMessageDetailsUserId = null;

            var accountDetails = userservices.GetAllUsers();


            //accountMessageDetailsUserId = userservices.GetAllUsers().Find(z => z.UserId == messageuserid);

            if(accountMessageDetailsUserId == listOfMessages.Find(p => p.UserNameId == messageuserid)) 
            {
                foreach (var messagecontent in listOfMessages)
                {
                    accountMessageDetailsEmail = userservices.GetAllUsers().Find(z => z.Email == email);
                    accountMessageDetailsPassword = userservices.GetAllUsers().Find(z => z.Password == password);
                    inboxMessages.Add(messagecontent);
                }
            }
            return inboxMessages(messageuserid);
        }
    }
}