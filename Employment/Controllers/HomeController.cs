using Employment.Models;
using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employment.Controllers
{
    public class HomeController : Controller
    {
        IUser _user;

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger,IUser user)
        {

            _logger = logger;
            _user = user;
        }


        public IActionResult Index()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult GetAllEmployeeUser()
        {
            var managerId = _user.GetUserByUserName(User.Identity.Name).Id;


            return View();
        }





    }
}