using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class EditUserPanel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="لطفا نام کاربری را وارد کنید")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "لطفا کلمه عبور را وارد کنید")]

        public string Password { get; set; }


        [Compare ("Password", ErrorMessage ="کلمه های عبور وارد شده با هم مطابقت ندارند")]
        [Required(ErrorMessage = "لطفا تکرار کلمه عبور را وارد کنید")]

        public string RePassword { get; set; }


    }
}
