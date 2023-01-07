using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DroosAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using DroosAcademy.CommonMethod;
using DroosAcademy.Models_For_Requests;
namespace DroosAcademy.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public StudentsController(DroosAcademyContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        // GET: api/Students
        [Authorize(Roles = "admin")]
        [HttpPost("Pagination")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents(paginationRequest pr)
        {
            List<Student> students = await _context.Students.ToListAsync();
            List<Student> studentsPaging = students.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentsPaging;
            return Ok(r);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = student;
            if (student == null)
            {
                return NotFound();
            }
            return Ok(r);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "student,admin")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = student;
            return Ok(r);
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            student.Balance = 0;
            student.Bonus = 0;
            await _context.SaveChangesAsync();
            Response r = new Response();
            Student s = await _context.Students.OrderBy(e => e.Id).LastOrDefaultAsync(e => e.Email == student.Email);
            r.message = "تم إنشاء الحساب بنجاح";
            r.data = s;
            return Ok(r);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "student,admin")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة الحساب بنجاح";
            r.data = null;
            return Ok(r);
        }
        [HttpPost("Authentication")]
        [AllowAnonymous]
        public async Task<ActionResult<Response>> Login(LoginRequest student)
        {
            //Student s = this._context.Students.FirstOrDefault(e => e.PhoneNumber == student.PhoneNumber && e.Password == student.Password);

            Response r = jwtAuthenticationManager.authenticateStudent(student.userName, student.password, _context);
            if (r == null)
            {
                return Unauthorized();
            }
            return Ok(r);
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}
