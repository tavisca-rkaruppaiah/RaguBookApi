using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Validators
{
    public class Validate
    {
        public static bool IsIdPositiveNumber(int id)
        {
            return id > 0;
        }
    }
}
