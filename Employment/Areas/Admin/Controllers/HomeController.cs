using Core;
using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Areas.Admin.Controllers
{
    [Area("Admin")]
    [PermissionChecker(1)]
    public class HomeController : Controller
    {
        IUser _user;


        public HomeController(IUser user)
        {
            _user = user;
        }


        public IActionResult Index()
        {
            var user = _user.GetUsers();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EditUserPanel user, List<int> SelectedPermissions)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (_user.IsExistUser(user.UserName.Trim()))
            {
                ModelState.AddModelError("Name", "این نام کاربری از قبل وجود دارد");
                return View();
            }


            if (SelectedPermissions.Count == 0)
            {
                ModelState.AddModelError("Name", "لطفا برای کاربر سطح دسترسی تعیین کنید");
                return View();
            }

            var admin = _user.GetUserByUserName(User.Identity.Name);


            _user.AddUserByAdmin(user, SelectedPermissions, admin.Id);




            return RedirectToAction("Index");

        }


        public IActionResult Edit(int userId)
        {
            var user = _user.GetUserByUserId(userId);

            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(User user, List<int> SelectedPermissions)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }


            if (SelectedPermissions.Count == 0)
            {
                ModelState.AddModelError("Name", "لطفا برای کاربر سطح دسترسی تعیین کنید");
                return View();
            }


            var admin = _user.GetUserByUserName(User.Identity.Name);


            _user.EditUserByAdmin(user, SelectedPermissions,admin.Id);

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int userId)
        {
            var user = _user.GetUserByUserId(userId);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(User user)
        {
            var admin = _user.GetUserByUserName(User.Identity.Name);
            _user.RemoveUserByAdmin(user,admin.Id);
            return RedirectToAction("Index");
        }

        public IActionResult ShowActivities(int userId)
        {
            var logs=_user.GetAllUserLog(userId);
            return View(logs);
        }
    }
}
