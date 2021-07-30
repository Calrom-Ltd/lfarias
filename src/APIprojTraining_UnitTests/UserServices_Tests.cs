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

        [DataRow(1, 1)]
        [DataTestMethod]
        public void GetUserById_FromUserList_IdIsValid(int id, object searchedUser)
        {
            //Arrange
            var userservices = new UserServices();

            var numberOfElements = userservices.listOfUsers.Count;
            //Act
            if (id == numberOfElements)
            {
                searchedUser = userservices.GetUserById(id);
            }
            //Assert
            Assert.AreEqual(searchedUser, id);
        }
    }
}