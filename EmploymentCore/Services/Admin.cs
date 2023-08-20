using EmploymentDataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public class Admin : IAdmin
    {

        MyContext _context;

        public Admin(MyContext context)
        {
            _context = context;
        }


        public void RemoveUserByAdmin(User user, int adminId)
        {

            _context.Users.Remove(user);
            _context.SaveChanges();

            UserLog log = new UserLog()
            {
                UserId = adminId,
                CreationDate = DateTime.Now.toshamsi(),
                Description = $"حذف کاربر {user.Name}"
            };

            _context.Add(log);
            _context.SaveChanges();
        }



        public void EditUserByAdmin(User user, List<int> permissions, int adminId, int? departmentId)
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



        public void AddUserByAdmin(EditUserPanel user, List<int> permissions, int adminId, int? departmentId)
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

        public List<HotelDepartment> GetDepartmentForAdmin()
        {
            return _context.HotelDepartments.ToList();
        }

        public void AddEmployeeByAdmin(EmployeeUser employeeUser, int adminId, int selectedDepartment)
        {
            EmployeeUser employee = new EmployeeUser()
            {
                DepartmentId = selectedDepartment,
                Name = employeeUser.Name,
            };
            _context.EmployeeUsers.Add(employee);
            _context.SaveChanges();

            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = adminId,
                Description = $"افزودن کارمند{employeeUser.Name}"
            };
            _context.Add(log);
            _context.SaveChanges();
        }

        public List<EmployeeUser> GetALLEmployeeByAdmin()
        {
            return _context.EmployeeUsers.ToList();
        }

        public List<EmployeeUser> GetEmployeeForManager(int managerId)
        {
            var manager = _context.Users.Include(u => u.UsersPermissions).Where(u => u.Id == managerId).SingleOrDefault();

            return _context.EmployeeUsers.Where(e => e.DepartmentId == manager.DepartmentId).ToList();
        }

        public EmployeeUser GetEmployeeUserForAdminById(int employeeId)
        {
            return _context.EmployeeUsers.Include(e=>e.HotelDepartment).Where(e=>e.EmployeeUserId == employeeId).SingleOrDefault();
        }

        public void DeleteEmployee(EmployeeUser employeeUser)
        {
            _context.Remove(employeeUser);
            _context.SaveChanges();
        }

        public void EditEmployee(EmployeeUser employeeUser, int? selectedDepartment)
        {
            if (selectedDepartment != null)
            {
                employeeUser.DepartmentId = selectedDepartment.Value;
            }

            _context.Update(employeeUser);
            _context.SaveChanges();
        }

        public List<FieldOfRating> GetAllFieldeOfRating()
        {
            return _context.FieldOfRatings.ToList();
        }

        public List<HotelDepartment> GetUserDepartment(int userId)
        {
            var departmentId = _context.Users.Where(u => u.Id == userId).Select(u => u.DepartmentId).SingleOrDefault();

            var department = _context.HotelDepartments.Where(h => h.DepartmentId == departmentId).ToList();

            return department;
        }

        public List<User> GetManagerOfDepartment(int departmentId)
        {
            return _context.Users.Where(u=>u.DepartmentId==departmentId).ToList() ;
        }

        public void AddRate(Rate rate, int managerId, int employeeId)
        {
            _context.Add(rate); 

            _context.SaveChanges();

            var employee = _context.EmployeeUsers.Find(employeeId);

            UserLog log = new UserLog()
            {
                UserId = managerId,
                CreationDate=DateTime.Now.toshamsi(),
                Description=$"امتیاز دهی به کاربر {employee.Name}"

            };

            _context.Add(log);
            _context.SaveChanges();

        }

        public List<Rate> GetAllRate()
        {
            return _context.Rates.Include(r => r.User).Include(r => r.EmployeeUser).Include(r => r.HotelDepartment).Include(r => r.FieldOfRating).OrderByDescending(r=>r.RateId).ToList();
        }

        public Rate GetRateBySearch(string parametr)
        {
            return _context.Rates.Include(r => r.User).Include(r => r.EmployeeUser).Include(r => r.HotelDepartment).Include(r => r.FieldOfRating).Where(r=>r.User.Name.Contains(parametr) || r.EmployeeUser.Name.Contains(parametr)).FirstOrDefault();
        }

        public List<Rate> SortRatesByAmount()
        {
           return _context.Rates.Include(r => r.User).Include(r => r.EmployeeUser).Include(r => r.HotelDepartment).Include(r => r.FieldOfRating).OrderByDescending(r=>r.Amount).ToList();
        }

        public EmployeeUser GetEmployeeUser(string userName)
        {
            return _context.EmployeeUsers.Where(u=>u.Name.Contains(userName)).FirstOrDefault();
        }
    }
}
