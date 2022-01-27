using System;

namespace SandS.Model
{
    static class MyExceptions
    {
        public static string DateStr(this DateTime date)
        {
            return date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
        }

        public static string GetTime(this DateTime date)
        {
            return date.ToString("HH:mm");
        }

        public static string DeleteErrors(this String str)
        {
            return str.Trim().Replace("'", "").Replace("`", "").Replace("(", "").Replace(")", "").Replace("/", "").Replace("\"", "");
        }
    }
}
