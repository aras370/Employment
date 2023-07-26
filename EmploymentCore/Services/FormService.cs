using EmploymentDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public class FormService : IForm
    {
        MyContext _context;

        public FormService(MyContext context)
        {
                _context = context;
        }

        public void AddForm(Employee form)
        {
            _context.Add(form);
            _context.SaveChanges();
        }
    }
}
