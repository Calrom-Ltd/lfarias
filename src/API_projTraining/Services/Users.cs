using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_projTraining.Services
{
    public class Users
    {
        private string Emails { get; set; }
        public string Password { get; set; }
    }
    public Users()
    {
        Email = "test@testmail.com";
        Password = "abc123";
    }
}

