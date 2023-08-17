using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class EmployeeUser
    {
        [Key]
        public int EmployeeUserId { get; set; }

        [Required(ErrorMessage ="لطفا نام پرسنل را وارد کنید")]
        public string Name { get; set; }


        [ForeignKey("HotelDepartment")]
        public int DepartmentId { get; set; }



        public HotelDepartment HotelDepartment { get; set; }

        public List<Rate> Rates { get; set; }

    }
}
