using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidName : IError
    {
        public int status = 100;
        public string message = "Name should be letters only";
    }
}
