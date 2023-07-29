using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmploymentDataLayer
{
    public class LiginViewModel
    {

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0}نمیتواند بیشتر از{1}کاراکتر باشد")]
        public string Name { get; set; }


        [MaxLength(50, ErrorMessage = "{0}نمیتواند بیشتر از{1}کاراکتر باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "کلمه عبور")]

        public string Password { get; set; }


        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

    }
}
