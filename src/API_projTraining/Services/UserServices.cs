using System.Collections.Generic;
using System.Linq;

namespace API_projTraining.Services
{
    public class UserServices : User
    {
        public ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers() =>
             _context.Users.ToList();

        public User GetUserById(int id) =>
            _context.Users.FirstOrDefault(z => z.UserId == id);

        public User GetUserEmail(string email) =>
            _context.Users.SingleOrDefault(y => y.Email == email);

        public User GetUserPassword(string password) =>
            _context.Users.SingleOrDefault(w => w.Password == password);
    }
}