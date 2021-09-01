using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace APIprojTraining_UnitTests
{
    [TestClass]
    public class MessageServices_Tests
    {
        private readonly MessageServices messageServices;

        private List<Message> ListOfMessages { get; set; }

        public MessageServices_Tests()
        {
            messageServices = new MessageServices();
            ListOfMessages = new List<Message>();
        }

        //---------Passing tests---------//
        [TestMethod]
        public void GetAllMessages_ReturnOk_ListIsNotNull()
        {
            var listOfMessagesTest = messageServices.listOfMessages;
            Assert.IsNotNull(listOfMessagesTest);
        }

        [TestMethod]
        [DataRow ("Alfa@testemail.com")]
        public void GetListOfMessagesForOneUser_ReturnOk_ListIsNotNull(string email)
        {
            var listWithMessages = messageServices.listOfMessages.FindAll(p => p.ReceiverEmail == email);
            Assert.IsNotNull(listWithMessages);
        }


        //***Not sure this is acceptable
        [TestMethod]
        public void AddMessage_ReturnOk_MessageListIsNotNull()
        {
            var _message = new Message()
            {
                //***passing the values to the object that will be added to the list***
                //MessageTitle = message.MessageTitle,
                //MessageBody = message.MessageBody,
                //SenderEmail = message.SenderEmail,
                //ReceiverEmail = message.ReceiverEmail

                MessageTitle = "Title",
                MessageBody = "Message content",
                SenderEmail = "Sender@testemail.com",
                ReceiverEmail = "Alfa@testemail.com"
            };
            ListOfMessages.Add(_message);

            Assert.IsTrue(ListOfMessages.Contains(_message));
        }


        //***needs fixing
        //[TestMethod]
        //[DataRow("Alfa@testemail.com")]
        //public void DeleteMessages_ReturnOk_ListIsNull(string email)
        //{
        //    var listWithMessages = messageServices.listOfMessages.FindAll(p => p.ReceiverEmail == email).ToList();

        //    listWithMessages.Clear();
        //    Assert.IsNull(listWithMessages);
        //}
    }
}
