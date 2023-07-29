using EmploymentDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{

    public class UserService:IUser
    {
        MyContext _context;


        public UserService(MyContext myContext)
        {
                _context = myContext;
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User LoginUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Name == username && u.Password == password);
        }
    }
}
