using EmploymentCore;
using EmploymentDataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employment.Controllers
{

    [Authorize]
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



        public ActionResult Confirm(int formId,string? comment)
        {

            _form.ConfirmEmployee(formId,comment);

            
            return Redirect("/");
        }

        public IActionResult DeleteForm(int formId)
        {
            _form.DeleteForm(formId);

            return RedirectToAction("GetAllForms");
        }

        public IActionResult FinalConfirmation(int formId)
        {

            _form.FinalConfirm(formId);

            return RedirectToAction("GetAllForms");
        }

        public IActionResult AcceptedPersons()
        {
            var employees = _form.GetAcceptedEmployees();
            return View(employees);
        }

        public IActionResult AcceptedPerson(int id)
        {
            var person=_form.GetAcceptedEmployeeById(id);
            return View(person);
        }
    }
}
