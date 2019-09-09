using RaguBookApi.Interfaces;
using RaguBookApi.Models;
using RaguBookApi.Validators;
using System.Collections.Generic;
using FluentValidation.Results;

namespace RaguBookApi.Services
{
    public class BookService : IServices
    {
        BookLibrary libray = new BookLibrary();
        BookValidator validate = new BookValidator();
        ValidationResult result;
        List<Error> errors = new List<Error>();
        public Response Delete(int id)
        {
            if(Validate.IsIdPositiveNumber(id))
            {
                if(libray.Remove(id))
                {
                    return new Response(new Book(), null);
                }
                else
                {
                    return new Response(null, new Error("Id", "IdNotFound"));
                }
            }
            else
            {
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }

        public List<Book> Get()
        {
            return libray.Get();
        }

        public Response Get(int id)
        {
            if(Validate.IsIdPositiveNumber(id))
            {
                if(libray.Get(id) != null)
                {
                    return new Response(libray.Get(id), null);
                }
                else
                {
                    return new Response(null, new Error("Id", "IdNotFound"));
                }
                
            }
            else
            {
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }

        public Response Post(Book book)
        {
            result = validate.Validate(book);
            if(result.IsValid)
            {
                libray.Add(book);
                return new Response(book, null);
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    errors.Add(new Error(error.PropertyName, error.ErrorMessage));
                }
                return new Response(null, errors[0]);
                
            }
        }

        public Response Put(int id, Book book)
        {
            result = validate.Validate(book);
            if(Validate.IsIdPositiveNumber(id))
            {
                if(result.IsValid)
                {
                    if (libray.Update(id, book))
                    {
                        return new Response(book, null);
                    }
                    else
                    {
                        return new Response(null, new Error("Id", "IdNotFound"));
                    }
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        errors.Add(new Error(error.PropertyName, error.ErrorMessage));
                    }
                    return new Response(null, errors[0]);
                }
            }
            else
            {
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }
    }
}
