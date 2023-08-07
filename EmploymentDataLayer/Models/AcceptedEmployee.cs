using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmploymentDataLayer
{
    public class AcceptedEmployee
    {

        [Key]
        public int Id { get; set; }

       

        public string Name { get; set; }



       
        public string LastName { get; set; }



        

        public string FhatherName { get; set; }



       

        public int CodeMelli { get; set; }



      
        public string BirthDate { get; set; }



     
        public string Marriege { get; set; }



     
        public int NumberOfChildren { get; set; }



       
        public string EducationLevel { get; set; }



     
        public string Major { get; set; }



   
        public string Univercity { get; set; }



      
        public string Address { get; set; }



      
        public string PhoneNumber { get; set; }

        //سوابق شغلی




       

        public string Formerjob { get; set; }



      
        public string StartDate { get; set; }



     
        public string EndDate { get; set; }



      

        public int Salary { get; set; }


 

        public string CauseOfLeave { get; set; }


       

        public string InformaionOfFormerBoss { get; set; }

      
        public int RequestedSalary { get; set; }

        //تاریخ پر کردن فرم

      

        public string DateTime { get; set; }

    }
}
