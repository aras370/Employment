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
        IUser _user;
        MyContext _context;
        public FormController(IForm form, IUser user, MyContext context)
        {
            _form = form;
            _user = user;
            _context = context;

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
            var user = _user.GetUserByUserName(User.Identity.Name);



            var form = _form.GetEmployeesForUser(user.Id);

            return View(form);
        }


        public IActionResult GetFormById(int id)
        {
            var form = _form.GetFormById(id);

            return View(form);

        }



        public IActionResult Confirm(int formId, string? comment,int userId)
        {

            _form.ConfirmEmployee(formId, comment,userId);


            return RedirectToAction("GetAllForms");
        }




        public IActionResult DeleteForm(int formId)
        {
            var user = _user.GetUserByUserName(User.Identity.Name);

            _form.DeleteForm(formId,user.Id);

            return RedirectToAction("GetAllForms");
        }

        public IActionResult FinalConfirmation(int formId, int userId)
        {

            _form.FinalConfirm(formId, userId);

            return RedirectToAction("GetAllForms");
        }

        public IActionResult AcceptedPersons()
        {
            var employees = _form.GetAcceptedEmployees();
            return View(employees);
        }

        public IActionResult AcceptedPerson(int id)
        {
            var person = _form.GetAcceptedEmployeeById(id);
            return View(person);
        }
    }
}
