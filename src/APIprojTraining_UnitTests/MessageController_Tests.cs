using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace APIprojTraining_UnitTests
{
    [TestClass]
    public class MessageController_Tests
    {
        private readonly MessageServices messageServices;
        private readonly UserServices userServices;

        public MessageController_Tests()
        {
            messageServices = new MessageServices();
            userServices = new UserServices();
        }

        //-----Passing tests-----
        [TestMethod]
        public void GetAllMessages_ReturnOk_ListIsNotNull()
        {
            var listWithAllMessages = messageServices.GetAllMessages();

            Assert.IsNotNull(listWithAllMessages);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com", "Alf49874")]
        public void GetListOfMessagesForOneUser_ReturnOk_ListIsNotNull(string email, string password)
        {
            var userLogin = userServices.ValidateLogin(email, password);
            
            if (userLogin != null)
            {
                var userMessageList = messageServices.GetListOfMessagesForOneUser(email);
                Assert.IsNotNull(userMessageList);
            }
        }


        //*****need fixing*****
        //[TestMethod]
        //[DataRow("Alfa@testemail.com", "Alf49874")]
        //public void AddMessage_ReturnOk_ListContainsNewMessage(string email, string password)
        //{
        //    var userLogin = userServices.ValidateLogin(email, password);

        //    if (userLogin != null)
        //    {
        //        var message = new Message()
        //        {
        //            //***passing the values to the object that will be added to the list***
        //            //MessageTitle = message.MessageTitle,
        //            //MessageBody = message.MessageBody,
        //            //SenderEmail = message.SenderEmail,
        //            //ReceiverEmail = message.ReceiverEmail

        //            MessageTitle = "Title",
        //            MessageBody = "Message content",
        //            SenderEmail = "Sender@testemail.com",
        //            ReceiverEmail = "Alfa@testemail.com"
        //        };
        //        messageServices.AddMessage(message);

        //        Assert.IsTrue(messageServices.listOfMessages.Contains(message));
        //    }
        //}


        //*****need fixing*****
        //[TestMethod]
        //[DataRow("Alfa@testemail.com", "Alf49874")]
        //public void DeleteMessages_ReturnOk_MessageListIsNull(string email, string password)
        //{
        //    var userLogin = userServices.ValidateLogin(email, password);

        //    if (userLogin != null)
        //    {
        //        var messages = messageServices.listOfMessages.Where(p => p.ReceiverEmail == email).ToList();
        //        messages.Clear();
        //        //messageServices.DeleteMessages(email);
        //        Assert.IsNull(messages);
        //    }
        //}
    }
}
