using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace APIprojTraining_UnitTests
{
    [TestClass]
    public class UserServices_Tests
    {
        private readonly UserServices userServices;

        public UserServices_Tests()
        {
            userServices = new UserServices();
        }

        //---------Passing tests---------//
        [TestMethod]
        public void GetAllUsers_UsersList_ListIsNotNull()
        {
            var listOfUserTest= userServices.listOfUsers;
            Assert.IsNotNull(listOfUserTest);
        }

        [TestMethod]
        [DataRow(1)]
        public void GetUserById_ReturnOk_UserIsNotNull(int id)
        {
            var userId = userServices.listOfUsers.FirstOrDefault(p => p.UserId == id);
            Assert.IsNotNull(userId);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com")]
        public void GetUserEmail_ReturnOk_EmailExist(string email)
        {
            var userEmail = userServices.listOfUsers.FirstOrDefault(p => p.Email == email);
            Assert.IsNotNull(userEmail);
        }

        [TestMethod]
        [DataRow("Alf49874")]
        public void GetUserPassword_ReturnOk_PasswordMatches(string password)
        {
            var userPassword = userServices.listOfUsers.FirstOrDefault(p => p.Password == password);
            Assert.IsNotNull(userPassword);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com", "Alf49874")]
        public void ValidateLogin_ReturnOk_EmailAndPasswordMatchDbInfo(string email, string password)
        {
            var userLogin = userServices.listOfUsers.FirstOrDefault(x => x.Email == email && x.Password == password);
            Assert.AreEqual(userLogin.Email == email, userLogin.Password == password);
        }

        //---------Failing tests---------//
        [TestMethod]
        public void GetAllUsers_UsersList_ListIsNull()
        {
            var listOfUserTest = userServices.listOfUsers;
            Assert.IsFalse(listOfUserTest == null);
        }

        [TestMethod]
        [DataRow(2)]
        public void GetUserById_ReturnOk_UserIsFalse(int id)
        {
            var userId = userServices.listOfUsers.FirstOrDefault(p => p.UserId == id);
            Assert.IsFalse(userId.UserId != 2);
        }

        [TestMethod]
        [DataRow("Bravo@testemail.com")]
        public void GetUserEmail_ReturnOk_EmailIsExist(string email)
        {
            var userEmail = userServices.listOfUsers.FirstOrDefault(p => p.Email == email);
            Assert.IsFalse(userEmail.Email == "Alfa@testemail.com");
        }

        [TestMethod]
        [DataRow("Br4v09874")]
        public void GetUserPassword_ReturnOk_PasswordDoesNotMatchDb(string password)
        {
            var userPassword = userServices.listOfUsers.FirstOrDefault(p => p.Password == password);
            Assert.IsFalse(userPassword.Password != "Br4v09874");
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com", "Alf49874")]
        public void ValidateLogin_ReturnOk_EmailAndPasswordDoesNotMatchDbInfo(string email, string password)
        {
            var userLogin = userServices.listOfUsers.FirstOrDefault(x => x.Email == email && x.Password == password);
            Assert.IsFalse(userLogin.Email != email && userLogin.Password != password);
        }
    }
}