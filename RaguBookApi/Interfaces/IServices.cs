using RaguBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Interfaces
{
    public interface IServices
    {
        Response Post(Book book);
        List<Book> Get();
        Response Get(int id);
        Response Put(int id, Book book);
        Response Delete(int id);
       
    }
}
