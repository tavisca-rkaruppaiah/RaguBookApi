using RaguBookApi.Interfaces;
using RaguBookApi.Models;
using RaguBookApi.Validators;
using System.Collections.Generic;
using FluentValidation.Results;
using System;

namespace RaguBookApi.Services
{
    public class BookService : IServices
    {
        BookLibrary libray = new BookLibrary();
        BookValidator validate = new BookValidator();
        ValidationResult result;
        List<Error> errors = new List<Error>();
        ILog logger = new FileLogger();
        public Response Delete(int id)
        {
            if(Validate.IsIdPositiveNumber(id))
            {
                if(libray.Remove(id))
                {
                    logger.Log("Deleted : " + "Successfully" + " " + DateTime.Now);
                    return new Response(new Book(), null);
                }
                else
                {
                    logger.Log("Error Occured while Deleting a Book : IdNotFound " + DateTime.Now);
                    return new Response(null, new Error("Id", "IdNotFound"));
                }
            }
            else
            {
                logger.Log("Error Occured while Deleting a Book : InValid Id Should Be Positive " + DateTime.Now);
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
                    logger.Log("Fetched : Successfully " + DateTime.Now);
                    return new Response(libray.Get(id), null);
                }
                else
                {
                    logger.Log("Error Occured while Geting Book : IdNotFound " + DateTime.Now);
                    return new Response(null, new Error("Id", "IdNotFound"));
                }
                
            }
            else
            {
                logger.Log("Error Occured while Getting Book : InValid Id Should Be Positive " + DateTime.Now);
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }

        public Response Post(Book book)
        {
            result = validate.Validate(book);
            if(result.IsValid)
            {
                libray.Add(book);
                logger.Log("Created : "+book.ToString() + " Added Successfully" + " " + DateTime.Now);
                return new Response(book, null);
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    errors.Add(new Error(error.PropertyName, error.ErrorMessage));
                }
                logger.Log("Error Occured while Creating Book : " + errors[0].message+" "+ DateTime.Now);
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
                        logger.Log("Updated :"+book.ToString() + " Updated Successfully");
                        return new Response(book, null);
                    }
                    else
                    {
                        logger.Log("Error in Updating Book : IdNotFound " + DateTime.Now);
                        return new Response(null, new Error("Id", "IdNotFound"));
                    }
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        errors.Add(new Error(error.PropertyName, error.ErrorMessage));
                    }
                    logger.Log("Error Occured while Updating Book : " + errors[0].message + " " + DateTime.Now);
                    return new Response(null, errors[0]);
                }
            }
            else
            {
                logger.Log("Error in Updating Book : InValid Id Should Be Positive " + DateTime.Now);
                return new Response(null, new Error("Id", "Invalid Id, Id should be a positive number"));
            }
        }
    }
}
