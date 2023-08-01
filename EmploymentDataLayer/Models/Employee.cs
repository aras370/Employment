using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string Name { get; set; }



        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string LastName { get; set; }



        [Display(Name = " نام پدر")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string FhatherName { get; set; }



        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
      
        public int CodeMelli { get; set; }



        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string  BirthDate { get; set; }



        [Display(Name = "وضعیت تاهل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string Marriege { get; set; }



        [Display(Name = "تعداد فرزندان")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
       
        public int NumberOfChildren { get; set; }



        [Display(Name = "تحصیلات")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string EducationLevel { get; set; }



        [Display(Name = "رشته تحصیلی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string Major { get; set; }



        [Display(Name = "دانشگاه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string Univercity { get; set; }



        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string Address { get; set; }



        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string PhoneNumber { get; set; }

        //سوابق شغلی




        [Display(Name = "شغل سابق")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string Formerjob { get; set; }



        [Display(Name = "تاریخ آغاز به کار")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string StartDate { get; set; }



        [Display(Name = "تاریخ پایان کار")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string EndDate { get; set; }



        [Display(Name = "سمت")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string Position { get; set; }



        [Display(Name = "حقوق")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
      
        public int Salary { get; set; }


        [Display(Name = "دلیل ترک")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string CauseOfLeave { get; set; }


        [Display(Name = "اطلاعات کارفرمای سابق")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string InformaionOfFormerBoss { get; set; }

        //سوابق شغلی پایان

        [Display(Name = "حقوق درخواستی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
      
        public int RequestedSalary { get; set; }

        //تاریخ پر کردن فرم

        [Display(Name = "تاریخ درخواست")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]

        public string DateTime { get; set; }

        public int Confirmation { get; set; }



        [Display(Name ="دیدگاه کارشناس:")]
        [MaxLength(300, ErrorMessage = " {0} نمیتواند بیشتر از {1} باشد")]
        public string? Comment { get; set; }

    }
}
