using EmploymentDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{

    public class UserService : IUser
    {
        MyContext _context;


        public UserService(MyContext myContext)
        {
            _context = myContext;
        }

        public void AddUserByAdmin(EditUserPanel user, List<int> permissions, int adminId)
        {
            User newuser = new User()
            {
                Name = user.UserName.Trim(),
                Password = user.Password.Trim(),
            };

            _context.Users.Add(newuser);
            _context.SaveChanges();
            foreach (var permission in permissions)
            {
                UsersPermission usersPermission = new UsersPermission()
                {
                    UserId = newuser.Id,
                    PermissionId = permission
                };
                _context.Add(usersPermission);
                _context.SaveChanges();
            };


            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = adminId,
                Description = $"افزودن کاربر {newuser.Name}"
            };
            _context.Add(log);
            _context.SaveChanges();
        }



        public void EditUserByAdmin(User user, List<int> permissions, int adminId)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            _context.UsersPermissions.Where(up => up.UserId == user.Id).ToList().ForEach(p => _context.UsersPermissions.Remove(p));
            foreach (var permission in permissions)
            {
                UsersPermission usersPermission = new UsersPermission()
                {
                    UserId = user.Id,
                    PermissionId = permission
                };
                _context.Add(usersPermission);
                _context.SaveChanges();
            };


            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = adminId,
                Description = $"تغییر اطلاعات کاربری یا دسترسی های {user.Name}"
            };
            _context.Add(log);
            _context.SaveChanges();

        }





        public bool CheckUserPermission(int permissionId, string userName)
        {


            var userId = _context.Users.Single(u => u.Name == userName).Id;

            List<int> userpermissions = _context.UsersPermissions.Where(up => up.UserId == userId).Select
                (up => up.PermissionId).ToList();


            return userpermissions.Any(ur => userpermissions.Contains(permissionId));


        }

        public void EditUser(EditUserPanel user, string userName)
        {
            var newuser = GetUserByUserId(user.Id);
            newuser.Name = user.UserName.Trim();
            newuser.Password = user.Password.Trim();
            _context.Update(newuser);
            _context.SaveChanges();

            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = user.Id,
                Description = " تغییر اطلاعات کاربری"
            };

            _context.Add(log);
            _context.SaveChanges();
        }



        public List<UserLog> GetAllUserLog(int userId)
        {
            return _context.UserLogs.Include(up => up.User).Where(ul => ul.UserId == userId).OrderByDescending(ur => ur.LogId).ToList();
        }

        public List<Permission> GetPermissions()
        {
            return _context.Permissions.Include(p => p.UsersPermissions).ToList();
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.Include(u => u.UsersPermissions).Where(u => u.Id == userId).SingleOrDefault();
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.Name == userName);
        }


        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User LoginUser(string username, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Name == username.Trim() && u.Password == password.Trim());
        }

        public void RemoveUserByAdmin(User user)
        {

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool IsExistUser(string username)
        {
           return _context.Users.Any(u=>u.Name == username.Trim());
        }
    }
}
