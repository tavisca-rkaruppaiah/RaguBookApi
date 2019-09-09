using RaguBookApi.Abstract;
using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Errors
{
    public class IdNotFound : Error
    {
        public IdNotFound() : base(404, "IdNotFound")
        {

        }
    }
}
