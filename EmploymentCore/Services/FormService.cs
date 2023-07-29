using EmploymentDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public class FormService : IForm
    {
        MyContext _context;

        public FormService(MyContext context)
        {
            _context = context;
        }

        public void AddForm(Employee form)
        {
            _context.Add(form);
            _context.SaveChanges();
        }

        public List<Employee> GetEmployeesForUser(int userId)
        {

            List<Employee> employees = new List<Employee>();

            switch (userId)

            {
                case 1:
                employees= _context.Employees.Where(e => e.FirstConfirm == false).ToList();
                    break;

                    case 2:
                    employees = _context.Employees.Where(e => e.FirstConfirm == true).ToList();
                    break;

                    case 3: employees = _context.Employees.Where(e => e.SecondConfirm == true).ToList();
                    break;

            }

            return employees;



        }

        public Employee GetFormById(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}
