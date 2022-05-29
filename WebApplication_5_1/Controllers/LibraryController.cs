using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_5_1.Models;

namespace WebApplication_5_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LibraryController : ControllerBase
    {
        [HttpGet("GetBook")]
        public Book GetBookbyId(int BookId)
        {
            return books.FirstOrDefault(b => b.Id == BookId);
        }

        [HttpGet("GetLibrary")]
        public Library GetLibraryById(int libraryId)
        {
            return libraries.FirstOrDefault(l => l.Id == libraryId);
        }

        [HttpPost("CreateLibrary")]
        public Library ? CreateLibrary(Library newLibrary)
        {
            libraries.Add(newLibrary);
            return newLibrary;
        }

        [HttpDelete("DeleteBook")]
        public List<Book> DeleteBook(int bookId)
        {
            var book = GetBookbyId(bookId);
            books.Remove(book);
            return books;
        }

        [HttpDelete("DeleteLibrary")]
        public List<Library> DeleteLibrary(int libraryId)
        {
            var library = GetLibraryById(libraryId);
            libraries.Remove(library);
            return libraries;
        }

        public static List<Book> books = new List<Book>()
        {
            new Book {Id = 1, Price = 500, Title = "NetworkProgrammingC#"},
            new Book {Id = 2, Price = 1000, Title = "ASP.NETC#"},
            new Book {Id = 3, Price = 5500, Title = "AJAX.NETC#"},
        };

        public static List<Library> libraries = new List<Library>() 
        { 
            new Library() {Id = 1, Name = "LibraryOfProgramming1", Books = books},
            new Library() {Id = 2, Name = "LibraryOfProgramming2", Books = books},
            new Library() {Id = 3, Name = "LibraryOfProgramming3", Books = books},
        };

    }
}
