using System;

namespace Assignment_Api.Helper
{
    public static class StringExtension
    {
        public static Guid GetGuid(this string guidAsString)
        {
            Guid guidOutput = Guid.Empty;
            Guid.TryParse(guidAsString, out guidOutput);
            return guidOutput;
        }

        public static bool IsGuid(this string guidAsString)
        {
            Guid guidOutput;
            return Guid.TryParse(guidAsString, out guidOutput);
        }

        public static string GetString(this Guid guidAsString)
        {
            return guidAsString.ToString();
        }
    }
}