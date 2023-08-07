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

        private readonly ILogger<HomeController> _logger;
        IForm _form;
        public HomeController(ILogger<HomeController> logger,IForm form)
        {
            _form = form;
            _logger = logger;
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



     

    }
}