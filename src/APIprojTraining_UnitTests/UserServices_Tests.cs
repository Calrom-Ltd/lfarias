using API_projTraining.Libraries;
using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIprojTraining_UnitTests
{

    [TestClass]
    public class UserServices_Tests
    {
        [TestMethod]
        public void GetAllUsers_UsersList_ListIsNotNull()
        {
            //Arrange
            var userservices = new UserServices();
            //Act
            var listOfUsers = userservices.GetAllUsers();
            //Assert
            Assert.IsNotNull(listOfUsers);
        }

        [TestMethod]
        [DataRow(1)]
        public void GetUserById_ReturnOk_UserExist(int id)
        {
            var userservices = new UserServices();
            var user = userservices.GetUserById(id);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        [DataRow("Alfa@testemail.com")]
        public void GetUserEmail_ReturnOk_EmailExist(string email)
        {
            var userservices = new UserServices();
            var userEmail = userservices.GetUserEmail(email);
            Assert.IsNotNull(userEmail);
        }

        [TestMethod]
        [DataRow("Alf49874")]
        public void GetUserPassword_ReturnOk_PasswordMatches(string password)
        {
            var userservices = new UserServices();
            var userPassword = userservices.GetUserPassword(password);
            Assert.IsNotNull(userPassword);
        }

        //[TestMethod]
        //[DataRow("Alfa@testemail.com", "Alf49874", 01)]
        //public void GetUserLogin_ReturnOk_EmailAndPasswordAreOk(string email, string password)
        //{
        //    var userservices = new UserServices();

        //    var userLogin = userservices.GetUserLogin(email, password) =>
        //        u => u.Userid == userservices.GetUserById(email));
 

        //    Assert.IsTrue(userLogin.UserId == 01);

        //}
    }
}