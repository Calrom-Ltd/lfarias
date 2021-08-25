using API_projTraining.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIprojTraining_UnitTests
{

    [TestClass]
    public class UserServices_Tests
    {
        public UserServices _userServices;
        //private ApplicationDbContext _context;

        //[TestInitialize]
        //public void TestInit(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public UserServices_Tests(UserServices userServices)
        {
            _userServices = userServices;
        }

        [TestMethod]
        public void GetAllUsers_UsersList_ListIsNotNull()
        {
            //Arrange
            //var userservices = new User();
            //Act
            var listOfUsers = _userServices.GetAllUsers();
            //Assert
            Assert.IsNotNull(listOfUsers);
        }

        [TestMethod]
        [DataRow(1)]
        public void GetUserById_ReturnOk_UserExist(int id)
        {
            //var userservices = new UserServices(_context);
            var user = _userServices.GetUserById(id);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        [DataRow("test@email.com")]
        public void GetUserEmail_ReturnOk_EmailExist(string email)
        {
            //var userservices = new UserServices(_context);
            var userEmail = _userServices.GetUserEmail(email);
            Assert.IsNotNull(userEmail);
        }

        [TestMethod]
        [DataRow("P4ssw0rdT3st")]
        public void GetUserPassword_ReturnOk_PasswordMatches(string password)
        {
            //var userservices = new UserServices(_context);
            var userPassword = _userServices.GetUserPassword(password);
            Assert.IsNotNull(userPassword);
        }
    }
}