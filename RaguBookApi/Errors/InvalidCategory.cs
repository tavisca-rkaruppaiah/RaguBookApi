using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidCategory : IError
    {
        public int status = 100;
        public string message = "Category should be letters only";
    }
}
