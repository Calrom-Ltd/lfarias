using System;
using System.Collections.Generic;

namespace API_projTraining.Services
{
    public class UserServices
    {
        public int[] id = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public string[] email = { "Alfa@testmail.com", "Bravo@testmail.com", "Charlie@testmail.com", "Delta@testmail.com", "Eco@testmail.com", "Foxtrot@testmail.com", "Golf@testmail.com", "Hotel@testmail.com", "India@testmail.com", "Juliet@testmail.com" };
        public string[] password = { "Alf49874", "Br4v09874", "Ch4rl139874", "D3lt49874", "3C09874", "F0str0t9874", "G01f9874", "H0t319874", "1nd149874", "Jul13t9874" };
        public long[] telephone = { 07788990000, 07744550000, 07755660000, 07711220000, 07722330000, 07733220000, 07722110000, 07766550000, 07755440000, 07799880000 };
        public string[] firstName = { "Alfa", "Bravo", "Charlie", "Delta", "Eco", "Foxtrot", "Golf", "Hotel", "India", "Juliet" };
        public string[] lastName = { "Arantes", "Bezerra", "Castro", "Dias", "Elias", "Ferreira", "Gomes", "Herrera", "Inacio", "Junqueira" };

        public User FindUser(int userId)
        {
            User myuser = new();
            if (userId == 1)
            {
                int i = userId - 1;
                myuser.Id = id[i];
                myuser.Email = email[i];
                myuser.Password = password[i];
                myuser.Telephone = telephone[i];
                myuser.FirstName = firstName[i];
                myuser.LastName = lastName[i];
            }
            else if (userId > 1 & userId < 11)
            {
                int i = userId - 1;
                myuser.Id = id[i];
                myuser.Email = email[i];
                myuser.Password = password[i];
                myuser.Telephone = telephone[i];
                myuser.FirstName = firstName[i];
                myuser.LastName = lastName[i];
            }
            return myuser;
        }

        public List<User> FindAllUsers()
        {
            int count = 1;
            int idx = 0;
            var myusers = new List<User>();
            do
            {
                User myuser = new();
                myuser.Id = id[idx];
                myuser.Email = email[idx];
                myuser.Password = password[idx];
                myuser.Telephone = telephone[idx];
                myuser.FirstName = firstName[idx];
                myuser.LastName = lastName[idx];
                myusers.Add(myuser);
                idx++;
                count++;
            }
            while (count >= 1 & count <= 10);
            return myusers;
        }

        public List<User> FindSomeUsers(int nOfUsers)
        {
            var count = 1;
            Random rnd = new();
            var rndUsers = new List<User>();
            do
            {
                int idx = rnd.Next(id.Length);
                User soloUser = new();
                soloUser.Id = id[idx];
                soloUser.Email = email[idx];
                soloUser.Password = password[idx];
                soloUser.Telephone = telephone[idx];
                soloUser.FirstName = firstName[idx];
                soloUser.LastName = lastName[idx];
                rndUsers.Add(soloUser);
                count++;
            } while (count <= nOfUsers);  
            return rndUsers;
        }
    }
}