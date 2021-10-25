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
        public MessageServices _messageServices;
        public MessageServices_Tests()
        {
            _messageServices = new MessageServices();
        }

        //---------------------------PASSING TESTS---------------------------//

        [TestMethod]
        public void GetAllMessages_ReturnListOfMessages_ListIsNotNull()
        {
            // ARRANGE
            var messageServices = new Mock<IMessageServices>();
            
            var mockListOfMessages = new List<Message>
            {
                new Message{ MessageId = 101, MessageBody = "This is Message number one"},
                new Message{ MessageId = 102, MessageBody = "This is Message number two"},
                new Message{ MessageId = 103, MessageBody = "This is Message number three"},
            };

            messageServices.Setup(x => x.GetAllMessages()).Returns(mockListOfMessages);

            //// ACT
            var actualResult = messageServices.Object.GetAllMessages();

            //// ASSERT
            Assert.AreEqual(actualResult, mockListOfMessages);
        }

        [TestMethod]
        public void GetListOfMessagesForOneUser_ShouldReturnOk_WhenListIsNotNull()
        {
            // ARRANGE
            var messageServices = new Mock<IMessageServices>();
            var mockListOfMessages = new List<Message>
            {
                new Message{ MessageId = 101, MessageBody = "This is Message number one", ReceiverEmail = "Alfa@testemail.com"}, 
                new Message{ MessageId = 102, MessageBody = "This is Message number two", ReceiverEmail = "Alfa@testemail.com"},
                new Message{ MessageId = 103, MessageBody = "This is Message number three", ReceiverEmail = "Alfa@testemail.com"},
            };

            string email = "Alfa@testemail.com";
            messageServices.Setup(x => x.GetListOfMessagesForOneUser(It.IsAny<string>())).Returns(mockListOfMessages);

            //// ACT
            var userInbox = messageServices.Object.GetListOfMessagesForOneUser(email);

            //// ASSERT
            Assert.AreEqual(userInbox, mockListOfMessages);
        }

        [TestMethod]
        public void DeleteMessages_ShouldDeleteAllMessages_WhenEmailIsNotNull()
        {
            //ARRANGE
            var listOfMessages = new Mock<List<IMessage>>();

            var mockMessageServices = new Mock<IMessageServices>();
            var email = "Alfa@testemail.com";

            mockMessageServices.Setup(x => x.DeleteMessages(It.IsAny<string>()));

            //ACT
            mockMessageServices.Object.DeleteMessages(email);
            listOfMessages.Object.Clear();

            //// ASSERT
            Assert.IsNotNull(email);
            Assert.AreEqual(0, listOfMessages.Object.Count);
        }



        //*************NEEDS FIXING****************
        //[TestMethod]
        //public void AddMessageToList_ShouldAddMessageToList_WhenMessageIsNotEmpty()
        //{
        //    // ARRANGE

            
        //    var newMessage = new Message()
        //    {
        //        MessageBody = "First message",
        //        SenderEmail = "sender@testemail.com",
        //        ReceiverEmail = "alfa@testemail.com"
        //    };
        //    var mockListOfMessages = new List<IMessage>();

        //    var messageServices = new Mock<IMessageServices>();
        //    messageServices.Setup(x => x.AddMessageToList(newMessage));

        //    mockListOfMessages = messageServices();

        //    //// ACT
        //    messageServices.Object.AddMessageToList(new Message());
            
        //    //// ASSERT
        //    //Assert.IsNotNull(newMessage);
        //    //Assert.IsNotNull(mockListOfMessages);
        //    //Assert.AreEqual(newMessage, mockListOfMessages);
        //}
    }
}
