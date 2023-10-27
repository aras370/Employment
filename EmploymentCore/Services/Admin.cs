using Dapper;
using EmploymentDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public class Admin : IAdmin
    {

        MyContext _context;
        IDbConnection _connection;
        public Admin(MyContext context, IDbConnection db)
        {
            _context = context;
            _connection = db;
        }


        #region LInq Methodes

        public async Task RemoveUserByAdmin(User user, int adminId)
        {

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            UserLog log = new UserLog()
            {
                UserId = adminId,
                CreationDate = DateTime.Now.toshamsi(),
                Description = $"حذف کاربر {user.Name}"
            };

            await _context.AddAsync(log);
            await _context.SaveChangesAsync();
        }



        public async Task EditUserByAdmin(User user, List<int> permissions, int adminId, int? departmentId)
        {
            if (departmentId != null)
            {
                user.DepartmentId = departmentId;

            }
            user.Name.Trim();
            user.Password.Trim();
            _context.Users.Update(user);
            _context.SaveChanges();
            _context.UsersPermissions.Where(up => up.UserId == user.Id).ToList().ForEach(p => _context.UsersPermissions.Remove(p));

            if (permissions.Count != 0)
            {
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
            }




            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = adminId,
                Description = $"تغییر اطلاعات کاربری یا دسترسی های {user.Name}"
            };
            _context.Add(log);
            _context.SaveChanges();

        }



        public async Task AddUserByAdmin(EditUserPanel user, List<int> permissions, int adminId, int? departmentId)
        {
            User newuser = new User()
            {
                Name = user.UserName.Trim(),
                Password = user.Password.Trim(),
                DepartmentId = departmentId
            };

            _context.Users.Add(newuser);
            _context.SaveChanges();

            if (permissions.Count != 0)
            {
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
            }



            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = adminId,
                Description = $"افزودن کاربر {user.UserName}"
            };
            _context.Add(log);
            _context.SaveChanges();


        }

        public async Task<List<HotelDepartment>> GetDepartmentForAdmin()
        {
            return _context.HotelDepartments.ToList();
        }

        //create
        public async Task AddEmployeeByAdmin(EmployeeUser employeeUser, int adminId, int selectedDepartment)
        {

            var query = $@"INSERT EmployeeUsers([Name],DepartmentId)

                        VALUES (@Name,{selectedDepartment}) ";

            await _connection.ExecuteAsync(query,employeeUser);


            //EmployeeUser employee = new EmployeeUser()
            //{
            //    DepartmentId = selectedDepartment,
            //    Name = employeeUser.Name,
            //};
            //await _context.EmployeeUsers.AddAsync(employee);
            //await _context.SaveChangesAsync();

            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = adminId,
                Description = $"افزودن کارمند{employeeUser.Name}"
            };

            var query2 = $@"INSERT UserLogs (CreationDate,UserId,Description)
                         VALUES (@CreationDate,@UserId,@Description)";

           await _connection.ExecuteAsync(query2,log);

            //await _context.AddAsync(log);
            //await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeUser>> GetALLEmployeeByAdmin()
        {
            var query = @"SELECT * FROM EmployeeUsers";
            var users = await _connection.QueryAsync<EmployeeUser>(query);
            return users.ToList();
        }

        public async Task<List<EmployeeUser>> GetEmployeeForManager(int managerId)
        {
            var manager = await _context.Users.Include(u => u.UsersPermissions).Where(u => u.Id == managerId).FirstOrDefaultAsync();



            return await _context.EmployeeUsers.Where(e => e.DepartmentId == manager.DepartmentId).ToListAsync();
        }

        public async Task<EmployeeUser> GetEmployeeUserForAdminById(int employeeId)
        {
            return await _context.EmployeeUsers.Include(e => e.HotelDepartment).Where(e => e.EmployeeUserId == employeeId).FirstOrDefaultAsync();
        }

        public async Task DeleteEmployee(EmployeeUser employeeUser)
        {
            //_context.Remove(employeeUser);
            //await _context.SaveChangesAsync();

            var query = $@"DELETE EmployeeUsers WHERE EmployeeUserId={employeeUser.EmployeeUserId}";

            await _connection.ExecuteAsync(query);

        }

        public async Task EditEmployee(EmployeeUser employeeUser, int? selectedDepartment)
        {
            if (selectedDepartment != null)
            {
                employeeUser.DepartmentId = selectedDepartment.Value;
            }

            _context.Update(employeeUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<FieldOfRating>> GetAllFieldeOfRating()
        {
            return await _context.FieldOfRatings.ToListAsync();
        }

        public async Task<List<HotelDepartment>> GetUserDepartment(int userId)
        {
            var departmentId = await _context.Users.Where(u => u.Id == userId).Select(u => u.DepartmentId).FirstOrDefaultAsync();

            return await _context.HotelDepartments.Where(h => h.DepartmentId == departmentId).ToListAsync();


        }

        public async Task<List<User>> GetManagerOfDepartment(int departmentId)
        {
            return await _context.Users.Where(u => u.DepartmentId == departmentId).ToListAsync();
        }

        public async Task AddRate(Rate rate, int managerId, int employeeId)
        {
            _context.Add(rate);

            await _context.SaveChangesAsync();

            var employee = await _context.EmployeeUsers.FindAsync(employeeId);

            UserLog log = new UserLog()
            {
                UserId = managerId,
                CreationDate = DateTime.Now.toshamsi(),
                Description = $"امتیاز دهی به کاربر {employee.Name}"

            };

            await _context.AddAsync(log);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Rate>> GetAllRate()
        {
            return await _context.Rates.Include(r => r.User).Include(r => r.EmployeeUser).Include(r => r.HotelDepartment).Include(r => r.FieldOfRating).OrderByDescending(r => r.RateId).ToListAsync();
        }

        public async Task<Rate> GetRateBySearch(string parametr)
        {
            return await _context.Rates.Include(r => r.User).Include(r => r.EmployeeUser).Include(r => r.HotelDepartment).Include(r => r.FieldOfRating).Where(r => r.User.Name.Contains(parametr) || r.EmployeeUser.Name.Contains(parametr)).FirstOrDefaultAsync();
        }

        public async Task<List<Rate>> SortRatesByAmount()
        {
            return await _context.Rates.Include(r => r.User).Include(r => r.EmployeeUser).Include(r => r.HotelDepartment).Include(r => r.FieldOfRating).OrderByDescending(r => r.Amount).ToListAsync();
        }

        public async Task<EmployeeUser> GetEmployeeUser(string userName)
        {
            return await _context.EmployeeUsers.Where(u => u.Name.Contains(userName)).FirstOrDefaultAsync();
        }





        #endregion

    }
}
