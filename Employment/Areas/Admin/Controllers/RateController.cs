using Core;
using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employment.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RateController : Controller
    {
        IAdmin _admin;
        IUser _user;

        public RateController(IAdmin admin, IUser user)
        {
            _admin = admin;
            _user = user;

        }
        [PermissionChecker(4)]
        public  IActionResult Index()
        {
            var user = _user.GetUserByUserName(User.Identity.Name);
            var employeeuser = _admin.GetEmployeeForManager(user.Id);
            return View(employeeuser);
        }


        [PermissionChecker(4)]
        public async Task<IActionResult>  Rate(int employeeId)
        {
            ViewBag.EmployeeId = employeeId;

            var manager = _user.GetUserByUserName(User.Identity.Name);

            ViewBag.Department = new SelectList(await _admin.GetUserDepartment(manager.Id), "DepartmentId", "Name");

            ViewBag.Manager = new SelectList(_user.GetUserForDepartment(User.Identity.Name), "Id", "Name");

            ViewBag.Employee = new SelectList( await _admin.GetEmployeeForManager(manager.Id), "EmployeeUserId", "Name");

            ViewBag.FieldOfRating = new SelectList(await _admin.GetAllFieldeOfRating(), "FieldOfRatingId", "Name");

            return View();
        }


        [HttpPost]
        public IActionResult Rate(Rate rate)
        {
            var manager = _user.GetUserByUserName(User.Identity.Name);

            _admin.AddRate(rate, manager.Id, rate.EmployeeUserId);


            return RedirectToAction("Index");
        }


        [PermissionChecker(1)]
        public async Task<IActionResult>  GetEmployeesScores()
        {
            var rates =await _admin.GetAllRate();
            ViewBag.issort = false;
            return View(rates);
        }

        [HttpPost]
        [PermissionChecker(1)]
        public async Task<IActionResult>  SearchScores(string parametr)
        {
            var scores =await _admin.GetRateBySearch(parametr);


            if (scores == null)
            {
                return View("notfound");
            }


            ViewBag.issort = false;

            return View("GetEmployeesScores", scores);
        }

        [PermissionChecker(1)]
        public async Task<IActionResult> SortByAmount()
        {
            var rates =await _admin.SortRatesByAmount();
            ViewBag.issort = true;
            return View("GetEmployeesScores", rates);
        }
    }
}
