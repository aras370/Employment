using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentDataLayer
{
    public class FieldOfRating
    {
        [Key]
        public int FieldOfRatingId { get; set; }

        public string Name { get; set; }


        #region

        public List<Rate> Rates { get; set; }

        #endregion

    }
}
