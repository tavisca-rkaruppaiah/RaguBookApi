using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RaguBookApi.Validation
{
    public class Validate
    {
        public static bool IsIdPositiveNumber(int id)
        {
            return id > 0;
        }

        public static bool IsStringContainsOnlyLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }
    }
}
