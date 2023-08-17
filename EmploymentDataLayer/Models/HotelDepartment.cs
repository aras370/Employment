using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class HotelDepartment
    {
        [Key]
        public int DepartmentId { get; set; }


        public string Name { get; set; }




        List<EmployeeUser> EmployeeUsers { get; set; }

        public User User { get; set; }

        public List<Rate> Rates { get; set; }
    }
}
