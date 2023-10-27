using EmploymentDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public interface IAdmin
    {

        Task AddUserByAdmin(EditUserPanel user, List<int> permissions, int adminId, int? departmentId);


        Task EditUserByAdmin(User user, List<int> permissions, int admiId, int? departmentId);


        Task RemoveUserByAdmin(User user, int adminId);


        Task<List<HotelDepartment>> GetDepartmentForAdmin();


        Task AddEmployeeByAdmin(EmployeeUser employeeUser, int adminId, int selectedDepartment);

        Task<List<EmployeeUser>> GetALLEmployeeByAdmin();


        Task<List<EmployeeUser>> GetEmployeeForManager(int managerId);


        Task<EmployeeUser> GetEmployeeUserForAdminById(int employeeId);


        Task EditEmployee(EmployeeUser employeeUser, int? selectedDepartment);

        Task DeleteEmployee(EmployeeUser employeeUser);

        Task<List<FieldOfRating>> GetAllFieldeOfRating();

        Task<List<HotelDepartment>> GetUserDepartment(int userId);

        Task<List<User>> GetManagerOfDepartment(int departmentId);


        Task AddRate(Rate rate, int managerId, int employeeId);


        Task<List<Rate>> GetAllRate();

        Task<Rate> GetRateBySearch(string parametr);

        Task<List<Rate>> SortRatesByAmount();

        Task<EmployeeUser> GetEmployeeUser(string userName);

    }
}
