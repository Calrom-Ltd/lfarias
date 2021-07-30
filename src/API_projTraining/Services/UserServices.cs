using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_projTraining.Services
{
    public class UserServices : User
    {
        public List<User> listOfUsers = new();

        public UserServices()
        {
            listOfUsers.Add(new User { UserId = 01, Email = "Alfa@testemail.com", Password = "Alf49874", FirstName = "Alfa", LastName = "Arantes" });
            listOfUsers.Add(new User { UserId = 02, Email = "Bravo@testmail.com", Password = "Br4v09874", FirstName = "Bravo", LastName = "Bezerra" });
            listOfUsers.Add(new User { UserId = 03, Email = "Charlie@testemail.com", Password = "Ch4rl139874", FirstName = "Charlie", LastName = "Castro" });
        }

        public List<User> GetAllUsers()
        {
            return listOfUsers;
        }

        public ActionResult<User> GetUserById(int id)
        {
            return listOfUsers.FirstOrDefault(z => z.UserId == id);
        }
    }
}