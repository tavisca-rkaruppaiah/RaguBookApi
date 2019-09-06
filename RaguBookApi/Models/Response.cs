using RaguBookApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Models
{
    public class Response
    {
        public Book book;
        public IError error;

        public Response(Book book, IError error)
        {
            this.book = book;
            this.error = error;
        }
    }
}
