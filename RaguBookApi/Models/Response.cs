using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Models
{
    public class Response
    {
        public Book book;
        public Error error;

        public Response(Book book, Error error)
        {
            this.book = book;
            this.error = error;
        }
    }
}
