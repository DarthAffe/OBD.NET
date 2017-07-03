using System;

namespace OBD.NET.Extensions
{
    public static class HexExtension
    {
        public static int GetHexVal(this char hex)
        {
            return hex - (hex < 58 ? 48 : (hex < 97 ? 55 : 87));
        }

        public static int GetHexVal(this string hex)
        {
            if ((hex.Length % 2) == 1)
                throw new ArgumentException("The binary key cannot have an odd number of digits");

            int result = 0;
            foreach (char c in hex)
                result = (result << 4) + (GetHexVal(c));

            return result;
        }
    }
}
