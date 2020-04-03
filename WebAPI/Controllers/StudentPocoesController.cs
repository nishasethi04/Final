using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityDataAccessLayer;
using StudentCourse;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPocoesController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentPocoesController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentPocoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentPoco>>> GetStudent()
        {
            return await _context.Student.ToListAsync();
        }

        // GET: api/StudentPocoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentPoco>> GetStudentPoco(Guid id)
        {
            var studentPoco = await _context.Student.FindAsync(id);

            if (studentPoco == null)
            {
                return NotFound();
            }

            return studentPoco;
        }

        // PUT: api/StudentPocoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentPoco(Guid id, StudentPoco studentPoco)
        {
            if (id != studentPoco.ID)
            {
                return BadRequest();
            }

            _context.Entry(studentPoco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentPocoExists(id))
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

        // POST: api/StudentPocoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<StudentPoco>> PostStudentPoco(StudentPoco studentPoco)
        {
            _context.Student.Add(studentPoco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentPoco", new { id = studentPoco.ID }, studentPoco);
        }

        // DELETE: api/StudentPocoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentPoco>> DeleteStudentPoco(Guid id)
        {
            var studentPoco = await _context.Student.FindAsync(id);
            if (studentPoco == null)
            {
                return NotFound();
            }

            _context.Student.Remove(studentPoco);
            await _context.SaveChangesAsync();

            return studentPoco;
        }

        private bool StudentPocoExists(Guid id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
