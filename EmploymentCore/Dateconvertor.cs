﻿using System;
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


        public static string ConvertToEasternArabicNumerals(string input)
        {
            System.Text.UTF8Encoding utf8Encoder = new UTF8Encoding();
            System.Text.Decoder utf8Decoder = utf8Encoder.GetDecoder();
            System.Text.StringBuilder convertedChars = new System.Text.StringBuilder();
            char[] convertedChar = new char[1];
            byte[] bytes = new byte[] { 217, 160 };
            char[] inputCharArray = input.ToCharArray();
            foreach (char c in inputCharArray)
            {
                if (char.IsDigit(c))
                {
                    bytes[1] = Convert.ToByte(160 + char.GetNumericValue(c));
                    utf8Decoder.GetChars(bytes, 0, 2, convertedChar, 0);
                    convertedChars.Append(convertedChar[0]);
                }
                else
                {
                    convertedChars.Append(c);
                }
            }
            return convertedChars.ToString();
        }


    }
}
