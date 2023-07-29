using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Controllers
{

    public class FormController : Controller
    {
        IForm _form;

        public FormController(IForm form)
        {
            _form = form;
        }

        [AllowAnonymous]
        public IActionResult Employment()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Employment(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            _form.AddForm(employee);
            return Redirect("/");
        }
        public IActionResult GetAllForms()
        {

            var form = _form.GetEmployeesForUser(int.Parse(User.Identity.Name));

            return View(form);
        }

        public IActionResult GetFormById(int id)
        {
            var form= _form.GetFormById(id);
            return View(form);

        }

    }
}
