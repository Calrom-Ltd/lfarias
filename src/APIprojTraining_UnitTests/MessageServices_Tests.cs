using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace APIprojTraining_UnitTests
{
    [TestClass]
    public class MessageServices_Tests
    {
        //private readonly MessageServices _messageServices;

        //private List<Message> ListOfMessages { get; set; }

        //public MessageServices_Tests()
        //{
        //    _messageServices = new MessageServices();
        //    ListOfMessages = new List<Message>();
        //}

        //---------------------------PASSING TESTS---------------------------//

        [TestMethod]
        public void GetAllMessages_ReturnListOfMessages_ListIsNotNull()
        {
            // ARANGE
            var moq_ListOfMessages = new List<Message>
            {
                new Message{ MessageId = 101, MessageBody = "This is Message number one"},
                new Message{ MessageId = 102, MessageBody = "This is Message number two"},
                new Message{ MessageId = 103, MessageBody = "This is Message number three"},
            };

            var messageService = new Mock<IMessageServices>();
            messageService.Setup(x => x.GetAllMessages()).Returns(moq_ListOfMessages);

            //// ACT
            var actualResult = messageService.Object.GetAllMessages();

            //// ASSERT
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        [DataRow ("Alfa@testemail.com")]
        public void GetListOfMessagesForOneUser_ReturnOk_ListIsNotNull(string email)
        {
            // ARANGE
            var moq_ListOfMessages = new List<Message>
            {
                new Message{ MessageId = 101, MessageBody = "This is Message number one", ReceiverEmail = "Alfa@testemail.com"},
                new Message{ MessageId = 102, MessageBody = "This is Message number two", ReceiverEmail = "Bravo@testemail.com"},
                new Message{ MessageId = 103, MessageBody = "This is Message number three", ReceiverEmail = "Charlie@testemail.com"},
            };

            var messageService = new Mock<IMessageServices>();

            messageService.Setup(x => x.GetListOfMessagesForOneUser(email)).Returns(moq_ListOfMessages);

            //// ACT
            var inbox = messageService.Object.GetListOfMessagesForOneUser(email);

            //// ASSERT
            Assert.IsNotNull(inbox);
        }

        [TestMethod]
        public void AddMessageToList_MessageIscreatedAndAdded_MessageIsInTheList()
        {

        }

        [TestMethod]
        [DataRow("Alfa@testemail.com")]
        public void DeleteMessages_ReturnOk_ListIsNull(string email)
        {

        }
    }
}
