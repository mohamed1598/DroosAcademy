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
    public class TeachersController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public TeachersController(DroosAcademyContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        //GET: api/Teachers
        [HttpPost("Pagination")]
        [Authorize(Roles = "admin")]
        //[AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers(paginationRequest pr)
        {
            List<Teacher> teachers = await _context.Teachers.ToListAsync();
            List<Teacher> teachersPaging = teachers.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = teachersPaging;
            return Ok(r);
        }

        //GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = teacher;
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(r);
        }
        //GET: api/Teachers/ahmed
        [HttpGet("TeacherName/{TeacherName}")]
        public async Task<ActionResult<Teacher>> GetTeacherByName(string TeacherName)
        {
            var teacher = await _context.Teachers
                .Where(e=>e.Fullname==TeacherName)
                .Include(e=>e.Subject)
                .Include(e=>e.TeachingYears)
                .ThenInclude(e=>e.Year)
                .FirstOrDefaultAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = teacher;
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(r);
        }
        //PUT: api/Teachers/5
        // To protect from overposting attacks, see
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
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
            r.data = teacher;
            return Ok(r);
        }

        //POST: api/Teachers
        //To protect from overposting attacks, see
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            Teacher t = await _context.Teachers.OrderBy(e => e.Id).LastOrDefaultAsync(e => e.Email == teacher.Email);
            Response r = new Response();
            r.message = "تم إنشاء الحساب بنجاح";
            r.data = t;
            return Ok(r);
        }

        //DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة الحساب بنجاح";
            r.data = null;
            return Ok(r);
        }

        //login
        [HttpPost("Authentication")]
        [AllowAnonymous]
        public async Task<ActionResult<Response>> Login(LoginRequest teacher)
        {
            //Teacher t = this._context.Teachers.FirstOrDefault(e => e.PhoneNumber == teacher.PhoneNumber && e.Password == teacher.Password);
            Response r = jwtAuthenticationManager.authenticateTeacher(teacher.userName, teacher.password, _context);
            if (r == null)
            {
                return Unauthorized();
            }
            return Ok(r);
        }

        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }
}
