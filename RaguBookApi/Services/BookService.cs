using Microsoft.AspNetCore.Mvc;
using RaguBookApi.Errors;
using RaguBookApi.Interfaces;
using RaguBookApi.Models;
using RaguBookApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaguBookApi.Services
{
    public class BookService : IServices
    {
        BookLibrary libray = new BookLibrary();

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
                    return new Response(null, new IdNotFound());
                }
            }
            else
            {
                return new Response(null, new InvalidId());
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
                    return new Response(null, new IdNotFound());
                }
                
            }
            else
            {
                return new Response(null, new InvalidId());
            }
        }

        public Response Post(Book book)
        {
            if(Validate.IsIdPositiveNumber(book.id))
            {
                if(Validate.IsStringContainsOnlyLetters(book.name))
                {
                    if(Validate.IsStringContainsOnlyLetters(book.category))
                    {
                        if(Validate.IsStringContainsOnlyLetters(book.author))
                        {
                            libray.Add(book);
                            return new Response(book, null);
                        }
                        else
                        {
                            return new Response(null, new InvalidAuthor());
                        }
                    }
                    else
                    {
                        return new Response(null, new InvalidCategory());
                    }
                }
                else
                {
                    return new Response(null, new InvalidName());
                }
            }
            else
            {
                return new Response(null, new InvalidId());
            }
        }

        public Response Put(int id, Book book)
        {
            if (Validate.IsIdPositiveNumber(id))
            {
                if(Validate.IsIdPositiveNumber(book.id))
                {
                    if (Validate.IsStringContainsOnlyLetters(book.name))
                    {
                        if (Validate.IsStringContainsOnlyLetters(book.category))
                        {
                            if (Validate.IsStringContainsOnlyLetters(book.author))
                            {
                                if (libray.Update(id, book))
                                {
                                    return new Response(book, null);
                                }
                                else
                                {
                                    return new Response(null, new IdNotFound());
                                }

                            }
                            else
                            {
                                return new Response(null, new InvalidAuthor());
                            }
                        }
                        else
                        {
                            return new Response(null, new InvalidCategory());
                        }
                    }
                    else
                    {
                        return new Response(null, new InvalidName());
                    }
                }
                else
                {
                    return new Response(null, new InvalidId());
                }
            }
            else
            {
                return new Response(null, new InvalidId());
            }
        }
    }
}
