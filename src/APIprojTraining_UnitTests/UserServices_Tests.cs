using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using API_projTraining.Libraries;
using System.Collections.Generic;

namespace APIprojTraining_UnitTests
{
    [TestClass]
    public class UserServices_Tests
    {
        //---------------------------PASSING TESTS---------------------------//

        [TestMethod]
        public void GetAllUsers_ReturnList_ListIsNotNull()
        {
            // ARANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com"},
                new User{ UserId = 02, Email = "Bravo@testemail.com"},
                new User{ UserId = 03, Email = "Charlie@testemail.com"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.GetAllUsers()).Returns(moq_ListOfUsers);

            //// ACT
            var actualResult = userService.Object.GetAllUsers();

            //// ASSERT
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        [DataRow(01)]
        public void GetUserById_ReturnUser_ValidId(int id)
        {
            //ARRANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com"},
                new User{ UserId = 02, Email = "Bravo@testemail.com"},
                new User{ UserId = 03, Email = "Charlie@testemail.com"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.GetUserById(id)).Returns(new User());

            //ACT
            var userId = userService.Object.GetUserById(id);

            //ASSERT
            Assert.AreEqual(userId.UserId, id);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com")]
        public void GetUserByEmail_ReturnUser_ValidEmail(string email)
        {
            //ARRANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com"},
                new User{ UserId = 02, Email = "Bravo@testemail.com"},
                new User{ UserId = 03, Email = "Charlie@testemail.com"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.GetUserByEmail(email)).Returns(new User());

            //ACT
            var userEmail = userService.Object.GetUserByEmail(email);

            //ASSERT
            Assert.AreEqual(userEmail.Email, email);
        }


        [TestMethod]
        [DataRow("Alf49874")]
        public void GetUserByPassword_ReturnOk_ValidPassword(string password)
        {
            //ARRANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Password = "Alf49874"},
                new User{ UserId = 02, Password = "Br4v09874"},
                new User{ UserId = 03, Password = "Ch4rli39874"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.GetUserByPassword(password)).Returns(new User());

            //ACT
            var userPassword = userService.Object.GetUserByPassword(password);

            //ASSERT
            Assert.AreEqual(userPassword.Password, password);
        }


        // NEEDS REVIEWING ABOUT NOT GETTING THE PARAMETIZED USER/PW FROM THE LIST.

        //[TestMethod]
        //[DataRow("Alfa@testemail.com", "Alf49874")]
        //public void ValidateLogin_ReturnUserEmailAndPassword_MatchDbInfo(string email, string password)
        //{
        //    //ARRANGE
        //    var moq_ListOfUsers = new List<User>
        //    {
        //        new User{ Email = "Alfa@testemail.com", Password = "Alf49874"},
        //        new User{ Email = "Bravo@testemail.com", Password = "Br4v09874"},
        //        new User{ Email = "Charlie@testemail.com", Password = "Ch4rl13"},
        //    };

        //    var userService = new Mock<IUserServices>();
        //    userService.Setup(x => x.ValidateLogin(It.IsAny<string>, It.IsAny<string>)).Returns(new User());

        //    //ACT
        //    var userLogin = userService.Object.ValidateLogin(email, password);

        //    //ASSERT
        //    Assert.AreEqual(userLogin.Email, email, userLogin.Password, password);
        //    //Assert.AreEqual(
        //}

        //---------------------------FAILING TESTS---------------------------//

        [TestMethod]
        public void GetAllUsers_ReturnList_ListIsNull()
        {
            // ARANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com"},
                new User{ UserId = 02, Email = "Bravo@testemail.com"},
                new User{ UserId = 03, Email = "Charlie@testemail.com"},
            };

            var userService = new Mock<IUserServices>();
            //the list is not returned to the userService object, thus the actualResult variable is empty
            userService.Setup(x => x.GetAllUsers());

            //// ACT
            var actualResult = userService.Object.GetAllUsers();

            //// ASSERT
            Assert.IsNull(actualResult);
        }

        [TestMethod]
        [DataRow(02)]
        public void GetUserById_ReturnUser_InvalidId(int id)
        {
            //ARRANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com"},
                new User{ UserId = 02, Email = "Bravo@testemail.com"},
                new User{ UserId = 03, Email = "Charlie@testemail.com"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.GetUserById(id)).Returns(new User());

            //ACT
            var userId = userService.Object.GetUserById(id);

            //ASSERT
            Assert.AreNotEqual(userId.UserId, id);
        }

        [TestMethod]
        [DataRow("Delta@testemail.com")]
        public void GetUserByEmail_ReturnUser_InvalidEmail(string email)
        {
            //ARRANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com"},
                new User{ UserId = 02, Email = "Bravo@testemail.com"},
                new User{ UserId = 03, Email = "Charlie@testemail.com"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.GetUserByEmail(email)).Returns(new User());

            //ACT
            var userEmail = userService.Object.GetUserByEmail(email);

            //ASSERT
            Assert.AreNotEqual(userEmail.Email, email);
        }

        [TestMethod]
        [DataRow("D3lt4")]
        public void GetUserByPassword_ReturnOk_InvalidPassword(string password)
        {
            //ARRANGE
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com", Password = "Alf49874"},
                new User{ UserId = 02, Email = "Bravo@testemail.com", Password = "Br4v09874"},
                new User{ UserId = 03, Email = "Charlie@testemail.com", Password = "Ch4rl13"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.GetUserByPassword(password)).Returns(new User());

            //ACT
            var userPassword = userService.Object.GetUserByPassword(password);

            //ASSERT
            Assert.AreNotEqual(userPassword.Password, password);
        }

        [TestMethod]
        [DataRow("Delta@testemail.com", "D3lt49874")]
        public void ValidateLogin_ReturnNothing_EmailAndPasswordAreInvalid(string email, string password)
        {
            var moq_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com", Password = "Alf49874"},
                new User{ UserId = 02, Email = "Bravo@testemail.com", Password = "Br4v09874"},
                new User{ UserId = 03, Email = "Charlie@testemail.com", Password = "Ch4rl13"},
            };

            var userService = new Mock<IUserServices>();
            userService.Setup(x => x.ValidateLogin(email, password)).Returns(new User());
            
            //ACT
            var userLogin = userService.Object.ValidateLogin(email, password);

            //ASSERT
            Assert.AreNotEqual(userLogin.Email, email, userLogin.Password, password);
        }
    }
}