using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OpencvMe.Common.Helper
{
    public static class GlobalExtension
    {
        public static string ToBase64(this string str)
        {
            byte[] encodedBytes = System.Text.Encoding.Unicode.GetBytes(str);
            return Convert.ToBase64String(encodedBytes);
        }
        public static string ToBase64(this int _int)
        {
            byte[] encodedBytes = System.Text.Encoding.Unicode.GetBytes(_int.ToString());
            return Convert.ToBase64String(encodedBytes);
        }
        public static string Base64ToString(this string base64Str)
        {
            byte[] decodedBytes = Convert.FromBase64String(base64Str);
            return System.Text.Encoding.UTF8.GetString(decodedBytes);
            // string decodedTxt2 = System.Text.Encoding.Unicode.GetString(decodedBytes);
        }
        public static int Base64ToInt(this string base64str)
        {
            byte[] decodedBytes = Convert.FromBase64String(base64str);
            var data = Convert.ToString(System.Text.Encoding.UTF8.GetString(decodedBytes));
            return Convert.ToInt32(System.Text.Encoding.UTF8.GetString(decodedBytes));
            // string decodedTxt2 = System.Text.Encoding.Unicode.GetString(decodedBytes);
        }

        // ay ve yıl
        public static string CustomDateStr (this DateTime date)
        {
            return  date.Year + " " +date.ToString("MMMM", CultureInfo.CreateSpecificCulture("tr"));
        }

        // ay gün yıl
        public static string CustomFullDateStr(this DateTime date)
        {
            return date.Day + " " + date.ToString("MMMM", CultureInfo.CreateSpecificCulture("tr")) + " " +  date.Year;
        }
    }
      
    public class GlobalHelper
    {
        

    }
}
