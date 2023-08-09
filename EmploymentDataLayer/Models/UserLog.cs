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
    public class UserLog
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int LogId { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }

        public string Description { get; set; }

        public string CreationDate { get; set; }




        #region Relations

        public User User { get; set; }

        #endregion


    }
}
