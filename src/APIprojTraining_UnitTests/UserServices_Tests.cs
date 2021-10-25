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
        public UserServices _userServices;

        public UserServices_Tests()
        {
            _userServices = new UserServices();
        }

        //---------------------------PASSING TESTS---------------------------//
        //OK
        [TestMethod]
        public void GetAllUsers_ShouldReturnList_WhenListIsNotNull()
        {
            // ARANGE
            var mock_ListOfUsers = new List<User>
            {
                new User{ UserId = 01, Email = "Alfa@testemail.com"},
                new User{ UserId = 02, Email = "Bravo@testemail.com"},
                new User{ UserId = 03, Email = "Charlie@testemail.com"},
            };

            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.GetAllUsers()).Returns(mock_ListOfUsers);

            //// ACT
            var actualResult = mockUserService.Object.GetAllUsers();

            //// ASSERT
            Assert.AreEqual(actualResult, mock_ListOfUsers);
        }

        [TestMethod]
        public void GetUserById_ShouldReturnUser_WhenIdIsValid()
        {
            //ARRANGE
            var mockUser = new User
            {
                UserId = 01,
                Email = "Alfa@testemail.com",
                FirstName = "Alfa",
                LastName = "Arantes",
                Password = "Alf49874"
            };
            int id = 01;
            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(mockUser);

            //// ACT
            var result = mockUserService.Object.GetUserById(id);

            //ASSERT
            Assert.AreEqual(id, result.UserId);
        }

        [TestMethod]
        public void GetUserByEmail_ShouldReturnUser_WhenEmailIsValid()
        {
            //ARRANGE
            var mockUser = new User
            {
                UserId = 01,
                Email = "Alfa@testemail.com",
                FirstName = "Alfa",
                LastName = "Arantes",
                Password = "Alf49874"
            };
            var email = "Alfa@testemail.com";

            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(mockUser);

            //ACT
            var userEmail = mockUserService.Object.GetUserByEmail(email);

            //ASSERT
            Assert.AreEqual(userEmail.Email, email);
        }


        [TestMethod]
        public void GetUserByPassword_ShouldReturnOk_WhenPasswordIsValid()
        {
            //ARRANGE
            var mockUser = new User
            {
                UserId = 01,
                Email = "Alfa@testemail.com",
                FirstName = "Alfa",
                LastName = "Arantes",
                Password = "Alf49874"
            };
            var password = "Alf49874";

            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.GetUserByPassword(It.IsAny<string>())).Returns(mockUser);
            
            //ACT
            var userPassword = mockUserService.Object.GetUserByPassword(password);

            //ASSERT
            Assert.AreEqual(userPassword.Password, password);
        }

        [TestMethod]
        public void ValidateLogin_ShouldReturnUserEmailAndPassword_WhenTheyMatchDb()
        {
            //ARRANGE
            var mockUser = new User
            {
                UserId = 01,
                Email = "Alfa@testemail.com",
                FirstName = "Alfa",
                LastName = "Arantes",
                Password = "Alf49874"
            };
            var email = "Alfa@testemail.com";
            var password = "Alf49874";

            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.ValidateLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(mockUser);

            //ACT
            var userLogin = mockUserService.Object.ValidateLogin(email, password);

            //ASSERT
            Assert.AreEqual(userLogin.Email, email);
            Assert.AreEqual(userLogin.Password, password);
        }


        //---------------------------FAILING TESTS---------------------------//

        [TestMethod]
        public void GetAllUsers_ShouldNotReturnList_WhenListIsEmpty()
        {
            // ARANGE
            var userService = new Mock<IUserServices>();
            
            ////the list is not being returned to the userService.Object, thus the *actualResult* variable is null
            userService.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            //// ACT
            var actualResult = userService.Object.GetAllUsers();

            //// ASSERT
            Assert.AreEqual(0, actualResult.Count);
        }

        [TestMethod]
        public void GetUserById_ShouldNotReturnUser_WhenIdIsInvalid()
        {
            //ARRANGE
            var mockUser = new User
            {
                UserId = 01,
                Email = "Alfa@testemail.com",
                FirstName = "Alfa",
                LastName = "Arantes",
                Password = "Alf49874"
            };
            int id = 015;            

            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(mockUser);

            //ACT
            var userId = mockUserService.Object.GetUserById(id);

            //ASSERT
            Assert.AreNotEqual(userId.UserId, id);            
        }

        [TestMethod]
        public void GetUserByEmail_ShouldNotReturnUser_WhenEmailIsInvalid()
        {
            //ARRANGE            
            string email = "zebra@testemail.com";

            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(new User());

            //ACT
            var userEmail = mockUserService.Object.GetUserByEmail(email);

            //ASSERT
            Assert.IsNull(userEmail.Email);
        }

        [TestMethod]
        public void GetUserByPassword_ShouldNotReturnUser_WhenPasswordIsInvalid()
        {
            //ARRANGE
            var mockUser = new User
            {
                UserId = 01,
                Email = "Alfa@testemail.com",
                FirstName = "Alfa",
                LastName = "Arantes",
                Password = "Alf49874"
            };
            string password = "Z3br49874";

            var mockUserService = new Mock<IUserServices>();
            mockUserService.Setup(x => x.GetUserByPassword(It.IsAny<string>())).Returns(mockUser);

            //ACT
            var userPassword = mockUserService.Object.GetUserByPassword(password);

            //ASSERT
            Assert.AreNotEqual(userPassword.Password, password);
        }

        [TestMethod]
        public void ValidateLogin_ShouldNotReturnUser_WhenBothEmailAndPasswordAreInvalid()
        {
            //ARRANGE
            var mockUserService = new Mock<IUserServices>();
            string email = "Zebra@testemail.com";
            string password = "Z3br49874";
            mockUserService.Setup(x => x.ValidateLogin(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new User());

            //ACT
            var userLogin = mockUserService.Object.ValidateLogin(email, password);

            //ASSERT
            Assert.IsNull(userLogin.Email);
            Assert.IsNull(userLogin.Password);
        }
    }
}