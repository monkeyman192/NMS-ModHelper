using System;
using System.Globalization;

namespace No_Mans_API.Extensions
{
    public static class StringExtensions
    {
        /*public static string ToHexCode(this string str)
        {

        }*/

        public static int ToIntFromHex(this string str)
        {
            if (str.StartsWith("0x"))
                str = str.Replace("0x", "");

            int.TryParse(str, NumberStyles.HexNumber, null, out int result);
            return result;
        }

        /*public static int ToInt(this string str)
        {
            int result = -1;

            if (string.IsNullOrEmpty(str))
                return result;

            if (str.StartsWith("0x"))
                str.Replace("0x", "");

            try { result = Convert.ToInt32(str, 16); }
            catch {  }

            return result;
        }*/
    }
}
