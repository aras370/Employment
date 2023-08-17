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

        public void ConfirmEmployee(int formId, string? comment, int userId)
        {
            var form = GetFormById(formId);
            form.Confirmation += 1;

            if (comment != null)
            {
                form.Comment = comment;
            }

            _context.Update(form);
            _context.SaveChanges();

            UserLog log = new UserLog()
            {
                UserId = userId,
                CreationDate=DateTime.Now.toshamsi(),
                Description=$"تایید فرم استخدام {form.LastName}"
            };

            _context.Add(log);
            _context.SaveChanges();

        }

        public void DeleteForm(int formId, int userId)
        {
            var form = GetFormById(formId);
            _context.Employees.Remove(form);
            _context.SaveChanges();

            UserLog log = new UserLog()
            {
                CreationDate=DateTime.Now.toshamsi(),
                UserId=userId,
                Description=$"حذف فرم استخدام {form.LastName}"
            };

            _context.Add(log);
            _context.SaveChanges();
        }

        public void FinalConfirm(int formId, int userId)
        {
            var form = GetFormById(formId);
            _context.Employees.Remove(form);
            _context.SaveChanges();



            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = userId,
                Description = $"تایید نهایی فرم استخدام {form.LastName}"
            };

            _context.Add(log);
            _context.SaveChanges();





            AcceptedEmployee employee = new AcceptedEmployee()
            {
                Address = form.Address,
                BirthDate = form.BirthDate,
                CauseOfLeave = form.CauseOfLeave,
                CodeMelli = form.CodeMelli,
                DateTime = form.DateTime,
                EducationLevel = form.EducationLevel,
                EndDate = form.EndDate,
                FhatherName = form.FhatherName,
                Formerjob = form.Formerjob,
                InformaionOfFormerBoss = form.InformaionOfFormerBoss,
                LastName = form.LastName,
                Major = form.Major,
                Marriege = form.Marriege,
                Name = form.Name,
                NumberOfChildren = form.NumberOfChildren,
                PhoneNumber = form.PhoneNumber,
                RequestedSalary = form.RequestedSalary,
                Salary = form.Salary,
                StartDate = form.StartDate,
                Univercity = form.Univercity
            };

            _context.AcceptedEmployees.Add(employee);
            _context.SaveChanges();
        }

        public AcceptedEmployee GetAcceptedEmployeeById(int id)
        {
            return _context.AcceptedEmployees.SingleOrDefault(emp => emp.Id == id);
        }

        public List<AcceptedEmployee> GetAcceptedEmployees()
        {
            return _context.AcceptedEmployees.ToList();
        }

        public List<Employee> GetEmployeesForUser(int userId)
        {

            List<Employee> employees = new List<Employee>();

            switch (userId)

            {
                case 3:
                    employees = _context.Employees.Where(e => e.Confirmation == 0).ToList();
                    break;

                case 2:
                    employees = _context.Employees.Where(e => e.Confirmation == 1).ToList();
                    break;

                case 1:
                    employees = _context.Employees.Where(e => e.Confirmation == 2).ToList();
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
