using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIprojTraining_UnitTests
{
    [TestClass]
    public class UserController_Tests
    {
        private readonly UserServices userServices;

        public UserController_Tests()
        {
            userServices = new UserServices();
        }

        //-----Passing tests-----
        [TestMethod]
        public void GetAllUser_ReturnOk_ListIsNotNull()
        {
            var listWithAllUsers = userServices.GetAllUsers();
            Assert.IsNotNull(listWithAllUsers);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com")]
        public void GetUserEmail_ReturnOk_EmailIsNotNull(string email)
        {
            var userEmail = userServices.GetUserEmail(email);
            Assert.IsNotNull(userEmail);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com", "Alf49874")]
        public void Login_ReturnOk_EmailAndPasswordIsNotNull(string email, string password)
        {
            var userLogin = userServices.ValidateLogin(email, password);
            Assert.IsNotNull(userLogin);
        }
    }
}
