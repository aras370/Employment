using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class User
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }


        [ForeignKey("HotelDepartment")]
        public int? DepartmentId { get; set; }


        #region Relations

        public List<UsersPermission> UsersPermissions { get; set; }

        public List<UserLog> UserLogs { get; set; }

        public HotelDepartment HotelDepartment { get; set; }

        public List<Rate> Rates { get; set; }

        #endregion
    }
}
