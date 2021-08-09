using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [DataRow(1, 1)]
        [DataTestMethod]
        public void GetUserById_FromUserList_IdIsValid(int id, object searchedUser)
        {
            //Arrange
            var userservices = new UserServices();
            int numberOfElements = userservices.listOfUsers.Count;

            //Act
            if (id <= numberOfElements)
            {
                searchedUser = userservices.listOfUsers.FirstOrDefault(z => z.UserId == id);
            }
            //Assert
            Assert.IsNotNull(searchedUser);
        }
    }
}