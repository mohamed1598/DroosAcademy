using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DroosAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using DroosAcademy.Models_For_Requests;

namespace DroosAcademy.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StudentTeacherBalancesController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public StudentTeacherBalancesController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/StudentTeacherBalances
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<StudentTeacherBalance>>> GetStudentTeacherBalances()
        {
            List<StudentTeacherBalance> studentTeacherBalances = await _context.StudentTeacherBalances.ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentTeacherBalances;
            return Ok(r);
        }

        // GET: api/StudentTeacherBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTeacherBalance>> GetStudentTeacherBalance(int id)
        {
            var studentTeacherBalance = await _context.StudentTeacherBalances.FindAsync(id);

            if (studentTeacherBalance == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentTeacherBalance;
            return Ok(r);
        }

        // PUT: api/StudentTeacherBalances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutStudentTeacherBalance(int id, StudentTeacherBalance studentTeacherBalance)
        {
            if (id != studentTeacherBalance.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentTeacherBalance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentTeacherBalanceExists(id))
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
            r.data = studentTeacherBalance;
            return Ok(r);
        }

        // POST: api/StudentTeacherBalances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<StudentTeacherBalance>> PostStudentTeacherBalance(StudentTeacherBalance studentTeacherBalance)
        {
            _context.StudentTeacherBalances.Add(studentTeacherBalance);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/StudentTeacherBalances/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteStudentTeacherBalance(int id)
        {
            var studentTeacherBalance = await _context.StudentTeacherBalances.FindAsync(id);
            if (studentTeacherBalance == null)
            {
                return NotFound();
            }

            _context.StudentTeacherBalances.Remove(studentTeacherBalance);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool StudentTeacherBalanceExists(int id)
        {
            return _context.StudentTeacherBalances.Any(e => e.Id == id);
        }
    }
}
