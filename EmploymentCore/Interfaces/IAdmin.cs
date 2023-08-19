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

        void AddUserByAdmin(EditUserPanel user, List<int> permissions, int adminId,int? departmentId);


        void EditUserByAdmin(User user, List<int> permissions, int admiId, int? departmentId);


        void RemoveUserByAdmin(User user, int adminId);


        List<HotelDepartment> GetDepartmentForAdmin();


       void AddEmployeeByAdmin(EmployeeUser employeeUser, int adminId, int selectedDepartment);

        List<EmployeeUser> GetALLEmployeeByAdmin();


        List<EmployeeUser> GetEmployeeForManager(int managerId);


        EmployeeUser GetEmployeeUserForAdminById(int employeeId);


        void EditEmployee(EmployeeUser employeeUser, int? selectedDepartment);

        void DeleteEmployee(EmployeeUser employeeUser);

        List<FieldOfRating> GetAllFieldeOfRating();

        List<HotelDepartment> GetUserDepartment(int userId);

        List<User> GetManagerOfDepartment(int departmentId);


        void AddRate(Rate rate,int  managerId, int employeeId);


        List<Rate> GetAllRate();

        List<Rate> GetRateBySearch(string parametr);

        List<Rate> SortRatesByAmount();
    }
}
