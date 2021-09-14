using API_projTraining.Controllers;
using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace APIprojTraining_UnitTests
{
    [TestClass]
    public class UserController_Tests
    {
        private readonly UserServices _userServices;

        public UserController_Tests()
        {
            _userServices = new UserServices();
        }

        //-----Passing tests-----
        [TestMethod]
        public void GetAllUser_ReturnOk_ListIsNotNull()
        {
            var listWithAllUsers = _userServices.GetAllUsers();
            Assert.IsNotNull(listWithAllUsers);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com")]
        public void GetUserEmail_ReturnOk_EmailIsNotNull(string email)
        {
            var userEmail = _userServices.GetUserByEmail(email);
            Assert.IsNotNull(userEmail);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com", "Alf49874")]
        public void Login_ReturnOk_EmailAndPasswordIsNotNull(string email, string password)
        {
            var userLogin = _userServices.ValidateLogin(email, password);
            Assert.IsNotNull(userLogin);
        }


        [TestMethod]
        public void Login_ValidUser_ReturnsOk()
        {
            //// ARANGE
            var userService = new Mock<IUserServices>();
            var email = "asdfas";
            var passw = "123412";
            userService.Setup(x => x.ValidateLogin(It.IsAny<string>(), It.IsAny<string>())).Returns(new User());

            var userController = new UserController(userService.Object);

            //// ACT
            var actionResult = userController.Login(email, passw);

            //// ASSERT
            Assert.IsNotNull(actionResult);
        }
    }
}
