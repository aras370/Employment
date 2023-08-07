using MessagePack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class UsersPermission
    {

        [System.ComponentModel.DataAnnotations.Key]
        public int UpId { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }



        [ForeignKey("Permission")]
        public int PermissionId { get; set; }



        #region Relations

        public User User { get; set; }


        public Permission Permission { get; set; }

        #endregion

    }
}
