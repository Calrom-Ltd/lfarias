using API_projTraining.Libraries;
using System.Collections.Generic;

namespace API_projTraining.Services
{
    public interface IUserServices
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        User GetUserByPassword(string password);
        User ValidateLogin(string email, string password);
    }
}