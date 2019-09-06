using RaguBookApi.Controllers;
using RaguBookApi.Errors;
using RaguBookApi.Models;
using RaguBookApi.Services;
using System;
using Xunit;

namespace RaguBookApi.Tests
{
    public class UnitTestForWebApi
    {
        BookService service = new BookService();
        Response response;
        Book book;
        [Fact]
        public void IsIdNegativeNumber()
        {
            response = service.Get(-1);
            Assert.Equal(new InvalidId().ToString(), response.error.ToString());

        }

        [Fact]
        public void CreateBook()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor",
                category = "SciFi",
                price = 200,
                author = "JKRowling"
            };

            response = service.Post(book);
            Assert.Equal(book.id, response.book.id);
        }

        [Fact]
        public void IsNameInvalid()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor1",
                category = "SciFi",
                price = 200,
                author = "JKRowling"
            };
            response = service.Post(book);
            Assert.Equal(new InvalidName().ToString(), response.error.ToString());

        }

        [Fact]
        public void IsCategoryInvalid()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor",
                category = "SciFi2",
                price = 200,
                author = "JKRowling"
            };
            response = service.Post(book);
            Assert.Equal(new InvalidCategory().ToString(), response.error.ToString());

        }

        [Fact]
        public void IsAuthorInvalid()
        {
            book = new Book()
            {
                id = 1,
                name = "HarryPottor",
                category = "SciFi",
                price = 200,
                author = "JKRowling12"
            };
            response = service.Post(book);
            Assert.Equal(new InvalidAuthor().ToString(), response.error.ToString());

        }
    }
}
