using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        public string Name { get; set; }



        #region Relations

        public List<UsersPermission> UsersPermissions { get; set; }

      

        #endregion
    }
}
