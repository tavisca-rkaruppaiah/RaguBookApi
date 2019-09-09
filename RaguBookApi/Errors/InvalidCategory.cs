using RaguBookApi.Abstract;
using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidCategory : Error
    {
        public InvalidCategory() : base(100, "Category should be letters only")
        {

        }
    }
}
