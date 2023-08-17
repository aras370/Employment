using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }

        [Display(Name ="بخش")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [ForeignKey("HotelDepartment")]
        public int DepartmentID { get; set; }



        [Display(Name = "مسئول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [ForeignKey("User")]
        public int ManagerId { get; set; }



        [Display(Name = "پرسنل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [ForeignKey("EmployeeUser")]
        public int EmployeeUserId { get; set; }



        [Display(Name = "نوع")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [ForeignKey("FieldOfRating")]
        public int FieldOfRatingId { get; set; }



        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }



        [Display(Name = "امتیاز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Score { get; set; }



        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }




        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Date { get; set; }



        #region Relations

        public HotelDepartment HotelDepartment  { get; set; }

        public User User { get; set; }

        public EmployeeUser EmployeeUser { get; set; }

        public FieldOfRating FieldOfRating { get; set; }

        #endregion
    }
}
