using System;
using System.Linq;

namespace OBD.NET.Common.Extensions
{
    public static class HexExtension
    {
        #region Methods

        public static int GetHexVal(this char hex) => hex - (hex < 58 ? 48 : (hex < 97 ? 55 : 87));
        public static int GetHexVal(this string hex)
        {
            if ((hex.Length % 2) == 1)
                throw new ArgumentException("The binary key cannot have an odd number of digits");

            return hex.Aggregate(0, (current, c) => (current << 4) + (GetHexVal(c)));
        }

        public static string ToHexString(this byte b) => ToHexString(new[] { b });
        public static string ToHexString(this byte[] bytes) => BitConverter.ToString(bytes).Replace("-", string.Empty);

        #endregion
    }
}
