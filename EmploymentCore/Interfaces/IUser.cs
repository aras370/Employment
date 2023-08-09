using EmploymentDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public interface IUser
    {

        User LoginUser(string username, string password);

        User GetUserByUserId(int userId);

        void EditUser(EditUserPanel user, string userName);

        List<User> GetUsers();

        List<Permission> GetPermissions();


        void AddUserByAdmin(EditUserPanel user, List<int> permissions);


        void EditUserByAdmin(User user, List<int> permissions);


        void RemoveUserByAdmin(User user);


        bool CheckUserPermission(int permissionId, string userName);


        User GetUserByUserName(string userName);


        List<UserLog> GetAllUserLog(int userId);


       
    }
}
