using Core;
using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Areas.Admin.Controllers
{
    [Area("Admin")]
    [PermissionChecker(1)]
    public class AdminController : Controller
    {

        IAdmin _admin;
        IUser _user;

        public AdminController(IAdmin admin, IUser user)
        {
            _admin = admin;
            _user = user;
        }


        public IActionResult Index()
        {
            var employees = _admin.GetALLEmployeeByAdmin();
            return View(employees);
        }


        public IActionResult AddEmployee()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult AddEmployee(EmployeeUser employee, int selectedDepartment)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            if (selectedDepartment == 0)
            {
                ModelState.AddModelError("Name", "بخش کاری را مشخص کنید");
                return View();
            }

            var admin = _user.GetUserByUserName(User.Identity.Name);

           

            _admin.AddEmployeeByAdmin(employee, admin.Id,selectedDepartment);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteEmployee(int employeeId)
        {
            var employee = _admin.GetEmployeeUserForAdminById(employeeId);
            return View(employee);
        }


        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeUser employee)
        {
            _admin.DeleteEmployee(employee);


            return RedirectToAction("Index");
        }


        public IActionResult EditEmployee(int employeeId)
        {
            ViewBag.Department = _admin.GetDepartmentForAdmin();
            var emplolee = _admin.GetEmployeeUserForAdminById(employeeId);
            return View(emplolee);
        }

        [HttpPost]
        public IActionResult EditEmployee(EmployeeUser employee, int? selectedDepartment)
        {
            _admin.EditEmployee(employee, selectedDepartment);


            return RedirectToAction("Index");

        }
    }
}
