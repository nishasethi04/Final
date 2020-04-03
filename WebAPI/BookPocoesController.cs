using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityDataAccessLayer;
using StudentCourse;

namespace WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookPocoesController : ControllerBase
    {
        private readonly StudentContext _context;

        public BookPocoesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/BookPocoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookPoco>>> Getbooks()
        {
            return await _context.books.ToListAsync();
        }

        // GET: api/BookPocoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookPoco>> GetBookPoco(int id)
        {
            var bookPoco = await _context.books.FindAsync(id);

            if (bookPoco == null)
            {
                return NotFound();
            }

            return bookPoco;
        }

        // PUT: api/BookPocoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookPoco(int id, BookPoco bookPoco)
        {
            if (id != bookPoco.BookId)
            {
                return BadRequest();
            }

            _context.Entry(bookPoco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookPocoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookPocoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BookPoco>> PostBookPoco(BookPoco bookPoco)
        {
            _context.books.Add(bookPoco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookPoco", new { id = bookPoco.BookId }, bookPoco);
        }

        // DELETE: api/BookPocoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookPoco>> DeleteBookPoco(int id)
        {
            var bookPoco = await _context.books.FindAsync(id);
            if (bookPoco == null)
            {
                return NotFound();
            }

            _context.books.Remove(bookPoco);
            await _context.SaveChangesAsync();

            return bookPoco;
        }

        private bool BookPocoExists(int id)
        {
            return _context.books.Any(e => e.BookId == id);
        }
    }
}
