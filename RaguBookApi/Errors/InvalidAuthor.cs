using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidAuthor : IError
    {
        public int status = 100;
        public string message = "AuthorName should be letters only";
    }
}
