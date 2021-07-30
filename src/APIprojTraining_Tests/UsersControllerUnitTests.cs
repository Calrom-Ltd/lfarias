using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIprojTraining_Tests
{
    [TestClass]
    public class UsersController_Tests
    {
        [TestMethod]
        public void FindAllUser_ListOfUsers_ReturnNotFound()
        {
            // Arrange
            var userservices = new UserServices();
            var oneuser = new User();
                        
            // Act
            var listofusers = UserServices.User(User oneuser);

            // Assert
            Assert.IsTrue(userservices.(result));
        }       
    }
}
    

