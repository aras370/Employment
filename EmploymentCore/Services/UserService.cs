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

        public void EditUser(EditUserPanel user)
        {
            var newuser = GetUserByUserId(user.Id);
            newuser.Name = user.UserName;
            newuser.Password= user.Password;
            _context.Update(newuser);
            _context.SaveChanges();
        }

        public List<Permission> GetPermissions()
        {
            return _context.Permissions.ToList();
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.Find(userId);
        }

        public List<User> GetUsers()
        {
           return _context.Users.ToList();
        }

        public User LoginUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Name == username && u.Password == password);
        }
    }
}
