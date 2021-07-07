using RaguBookApi.Abstract;
using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidAuthor : Error
    {
        public InvalidAuthor() : base(100, "AuthorName should be letters only")
        {

        }
    }
}
