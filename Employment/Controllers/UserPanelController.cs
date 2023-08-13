using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Controllers
{
    public class UserPanelController : Controller
    {
        IUser _user;


        public UserPanelController(IUser user)
        {
            _user = user;
        }




        public IActionResult Panel(int id)
        {
            var user = _user.GetUserByUserId(id);

            return View(user);
        }


        public IActionResult EditUserInformation(int userId)
        {

            ViewBag.userid = userId;
            var user = _user.GetUserByUserId(userId);
            ViewBag.name = user.Name;
            ViewBag.password = user.Password;
            return View();
        }

        
        [HttpPost]
        public IActionResult EditUserInformation(EditUserPanel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (_user.IsExistUser(user.UserName))
            {
                ModelState.AddModelError("UserName", "این نام کاربری از قبل انتخاب شده است");
                return View();
            }


            _user.EditUser(user);


            return Redirect("/UserPanel/Panel/" + user.Id);

        }

    }
}
