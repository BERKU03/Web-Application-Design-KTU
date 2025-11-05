using Microsoft.AspNetCore.Mvc;
using System;
using DigitalLibrary.Models;
using DigitalLibrary.Data;
using Microsoft.EntityFrameworkCore;


namespace DigitalLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly DigitalLibraryContext _context;

        public BooksController(DigitalLibraryContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _context.Books
                .Include(b => b.Category)
                .ToListAsync();

            return Ok(books);
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            if (book == null)
            {
                return NotFound("Book is null");
            }

            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == book.CategoryId);
            if (!categoryExists)
            {
                return BadRequest($"The category {book.CategoryId} non exist.");

            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            await _context.Entry(book).Reference(b => b.Category).LoadAsync();//recargar la categoria y devuelve el libro compeleto
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
        

