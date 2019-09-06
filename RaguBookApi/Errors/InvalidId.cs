using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidId : IError
    {
        public int status = 100;
        public string message = "Invalid Id, Id should be a positive number";
    }
}
