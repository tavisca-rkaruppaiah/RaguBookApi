using RaguBookApi.Abstract;
using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidName : Error
    {
        public InvalidName() : base(100, "Name should be letters only")
        {

        }
    }
}
