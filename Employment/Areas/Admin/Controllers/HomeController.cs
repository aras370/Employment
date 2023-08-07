using EmploymentCore;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}
