using System;

namespace NMS_ModHelper.Api.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Returns the Hex Code equivalent of this number
        /// </summary>
        /// <param name="b"></param>
        /// <param name="include_0x">should "0x" be included at the front of returned value?</param>
        /// <returns></returns>
        public static string ToHexCode(this byte b, bool include_0x = true)
        {
            if (b < 0 || b > 15)
            {
                Logger.Log("byte.ToHexCode: input out of range for Hex value", LogLevel.Error);
                return null;
            }

            var hex = b < 10 ? (char)(b + 48) : (char)(b + 55);
            return hex.ToString();
        }

        /// <summary>
        /// Return if the Hex Value of this number is equal to another Hex Value
        /// </summary>
        /// <param name="number"></param>
        /// <param name="equalToHex">Hex Value that we're comparing to</param>
        /// <returns></returns>
        public static bool IsHexEqualTo(this byte number, string equalToHex)
        {
            return number.ToHexCode(false) == equalToHex;
        }
    }
}
