using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Inside BooksController.cs
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest();
            }

            _context.Books.Add(newBook);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }
        // Inside BooksController.cs
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var existingBook = _context.Books.Find(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            // Update other properties as needed

            _context.SaveChanges();

            return Ok(existingBook);
        }


    }
}
