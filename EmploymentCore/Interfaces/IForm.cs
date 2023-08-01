using EmploymentDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public interface IForm
    {
        void AddForm(Employee form);

        List<Employee> GetEmployeesForUser(int userId);

        Employee GetFormById(int id);

        void ConfirmEmployee(int formId,string? comment);

        void DeleteForm(int formId);

        void FinalConfirm(int formId);

        List<AcceptedEmployee> GetAcceptedEmployees();

        AcceptedEmployee GetAcceptedEmployeeById(int id);
    }
}
