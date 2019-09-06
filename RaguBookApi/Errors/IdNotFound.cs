using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class IdNotFound : IError
    {
        public int status = 404;
        public string message = "IdNotFound";
    }
}
