using RaguBookApi.Abstract;
using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class InvalidId : Error
    {
        public InvalidId():base(100, "Invalid Id, Id should be a positive number")
        {

        }
    }
}
