using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Employment.Controllers
{
    public class AccountController : Controller
    {

        IUser _user;
        MyContext _context;

        public AccountController(IUser user1, MyContext myContext)
        {
            _user = user1;
            _context = myContext;
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LiginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _user.LoginUser(login.Name, login.Password);

            if (user == null)
            {
                ModelState.AddModelError("Name", "کاربری با این مشخصات وجود ندارد");
                return View();
            }


            var claims = new List<Claim>()
            {

                new Claim(ClaimTypes.Name , user.Name),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.RememberMe
            };


            HttpContext.SignInAsync(principal, properties);


            var user1 = _user.GetUserByUserName(login.Name);

            UserLog log = new UserLog()
            {
                CreationDate = DateTime.Now.toshamsi(),
                UserId = user1.Id,
                Description = "ورود به سیستم"
            };

            _context.Add(log);
            _context.SaveChanges();

            return Redirect("/UserPanel/Panel/" + user.Id);
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }



    }
}
