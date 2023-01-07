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
    [ApiController]
    [Authorize]
    public class StudentHaveLecturesController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public StudentHaveLecturesController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/StudentHaveLectures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentHaveLecture>>> GetStudentHaveLectures()
        {
            List<StudentHaveLecture> studentHaveLectures = await _context.StudentHaveLectures.ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentHaveLectures;
            return Ok(r);
        }

        // GET: api/StudentHaveLectures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentHaveLecture>> GetStudentHaveLecture(int id)
        {
            var studentHaveLecture = await _context.StudentHaveLectures.FindAsync(id);

            if (studentHaveLecture == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentHaveLecture;
            return Ok(r);
        }

        // PUT: api/StudentHaveLectures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutStudentHaveLecture(int id, StudentHaveLecture studentHaveLecture)
        {
            if (id != studentHaveLecture.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentHaveLecture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentHaveLectureExists(id))
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
            r.data = studentHaveLecture;
            return Ok(r);
        }

        // POST: api/StudentHaveLectures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<StudentHaveLecture>> PostStudentHaveLecture(StudentHaveLecture studentHaveLecture)
        {
            _context.StudentHaveLectures.Add(studentHaveLecture);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/StudentHaveLectures/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteStudentHaveLecture(int id)
        {
            var studentHaveLecture = await _context.StudentHaveLectures.FindAsync(id);
            if (studentHaveLecture == null)
            {
                return NotFound();
            }

            _context.StudentHaveLectures.Remove(studentHaveLecture);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = null;
            return Ok(r);
        }
        // GET: api/StudentHaveLectures/StudentValidLectures/5
        [HttpGet("StudentValidLectures/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<List<StudentHaveLecture>>> GetStudentValidLectures(int id)
        {
            DateTime timeNow = DateTime.Now;
            var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == id && timeNow <= e.Enddate)
                .Include(e => e.Lecture)
                .Include(e => e.Teacher)
                .ToListAsync();

            if (studentHaveLecture == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentHaveLecture;
            return Ok(r);
        }
        // GET: api/StudentLectures/StudentLectures/5
        [HttpGet("StudentLectures/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<List<StudentHaveLecture>>> GetStudentLectures(int studentId)
        {
            var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == studentId)
                .Include(e => e.Lecture)
                .Include(e => e.Teacher)
                .ToListAsync();

            if (studentHaveLecture == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentHaveLecture;
            return Ok(r);
        }
        // POST: api/StudentHaveLectures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("ValidStudentAndTeacherCommonLectures/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<List<StudentHaveLecture>>> getValidStudentAndTeacherCommonLectures(StudentHaveLecture studentHaveLecture)
        {
            DateTime timeNow = DateTime.Now;
            var s = await _context.StudentHaveLectures.Where(e =>
                e.StudentId == studentHaveLecture.StudentId
                && e.TeacherId == studentHaveLecture.TeacherId
                && e.Enddate >= timeNow)
                .Include(e => e.Lecture)
                .Include(e => e.Teacher)
                .ToListAsync();

            if (s == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = s;
            return Ok(r);
        }
        [HttpPost("StudentAndTeacherCommonLectures/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<List<StudentHaveLecture>>> getStudentAndTeacherCommonLectures(StudentHaveLecture studentHaveLecture)
        {
            var s = await _context.StudentHaveLectures.Where(e => e.StudentId == studentHaveLecture.StudentId && e.TeacherId == studentHaveLecture.TeacherId)
                .Include(e => e.Lecture)
                .Include(e => e.Teacher)
                .ToListAsync();

            if (s == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = s;
            return Ok(r);
        }
        // GET: api/StudentLectures/LecturesNumberForStudent/5
        [HttpGet("LecturesNumberForStudent/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<int>> GetStudentLecturesNumber(int studentId)
        {
            DateTime timeNow = DateTime.Now;
            var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == studentId && timeNow <= e.Enddate).ToListAsync();

            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentHaveLecture.Count;
            return Ok(r);
        }
        // GET: api/StudentLectures/TeacherNumberForStudent/5
        [HttpGet("TeachersNumberForStudent/{id}")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<int>> GetStudentTeachersNumber(int studentId)
        {
            DateTime timeNow = DateTime.Now;
            var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == studentId && timeNow <= e.Enddate).GroupBy(x => x.TeacherId).Select(x => x.First()).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentHaveLecture.Count;
            return Ok(r);

        }
        //private async Task<List<StudentHaveLecture>> lectureNumbersForStudent(int id)
        //{
        //    DateTime timeNow = DateTime.Now;
        //    var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == id && timeNow <= e.Enddate)
        //        .Include(e => e.Lecture)
        //        .Include(e => e.Teacher)
        //        .ToListAsync();
        //    return studentHaveLecture;
        //}
        private bool StudentHaveLectureExists(int id)
        {
            return _context.StudentHaveLectures.Any(e => e.Id == id);
        }
    }
}
