using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Abstract
{
    public abstract class Error
    {
        public int status { get; }
        public string message { get;  }

        public Error(int status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
