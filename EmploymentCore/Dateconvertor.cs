using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCore
{
    public static class Dateconvertor
    {
        public static string toshamsi(this DateTime dateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(dateTime) + "/" + pc.GetMonth(dateTime).ToString("00") + "/" +
                pc.GetDayOfMonth(dateTime).ToString("00") +" "+ DateTime.Now.ToString("HH:mm:ss tt");
        }
    }
}
