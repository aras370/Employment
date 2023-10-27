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


        public async Task<IActionResult> Index()
        {

            var employees = await _admin.GetALLEmployeeByAdmin();
            return View(employees);
        }


        public async Task<IActionResult> SearchEmployee(string userName)
        {
            var employee =await _admin.GetEmployeeUser(userName);

            if (employee == null)
            {
                return View("notfound");
            }

            return View(employee);
        }


        public IActionResult AddEmployee()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeUser employee, int selectedDepartment)
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



          await  _admin.AddEmployeeByAdmin(employee, admin.Id, selectedDepartment);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var employee =await _admin.GetEmployeeUserForAdminById(employeeId);
            return View(employee);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(EmployeeUser employee)
        {
           await _admin.DeleteEmployee(employee);


            return RedirectToAction("Index");
        }


        public async Task<IActionResult> EditEmployee(int employeeId)
        {
            ViewBag.Department =await _admin.GetDepartmentForAdmin();
            var emplolee =await _admin.GetEmployeeUserForAdminById(employeeId);
            return View(emplolee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeUser employee, int? selectedDepartment)
        {
           await _admin.EditEmployee(employee, selectedDepartment);


            return RedirectToAction("Index");

        }
    }
}
