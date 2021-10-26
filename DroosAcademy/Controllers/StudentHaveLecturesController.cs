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
using DroosAcademy.CommonMethod;

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
        [Authorize(Roles = "admin")]
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
        //[AllowAnonymous]
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
        [HttpGet("StudentLectures/{studentId}")]
        public async Task<ActionResult<List<StudentHaveLecture>>> GetStudentLectures(int studentId)
        {
            var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == studentId)
                .Include(e => e.Lecture)
                .Include(e => e.Teacher)
                .ToListAsync();
            List<Lecture> lectures = new List<Lecture>();
            foreach (var item in studentHaveLecture)
            {
                var lecture = await _context.Lectures.Where(e => e.Id == item.LectureId)
                    .Include(e => e.Subject)
                    .Include(e => e.Teacher)
                    .Include(e => e.StudentHaveLectures)
                    .FirstOrDefaultAsync();
                lectures.Add(lecture);
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lectures;
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
        [HttpGet("LecturesNumberForStudent/{studentId}")]
        //[Authorize(Roles = "admin,student")]
        [AllowAnonymous]
        public async Task<ActionResult<int>> GetStudentLecturesNumber(int studentId)
        {
            DateTime timeNow = DateTime.Now;
            var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == studentId)
                .GroupBy(e=>e.LectureId)
                .Select(x => new StudentHaveLecture()
                {
                    StudentId = x.Max(e => e.LectureId)
                })
                .ToListAsync();

            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = studentHaveLecture.Count;
            return Ok(r);
        }
        // GET: api/StudentLectures/TeacherNumberForStudent/5
        [HttpGet("TeachersNumberForStudent/{studentId}")]
        [Authorize(Roles = "admin,student")]
        //[AllowAnonymous]
        public async Task<ActionResult<int>> GetStudentTeachersNumber(int studentId)
        {
            DateTime timeNow = DateTime.Now;
            List<Teacher> teachers = new List<Teacher>();
            var studentHaveLecture = await _context.StudentHaveLectures
                .Where(e => e.StudentId == studentId)
                .GroupBy(x => x.TeacherId)
                .Select(x => new StudentHaveLecture()
                {
                    StudentId = x.Max(e => e.StudentId),
                    TeacherId = x.Max(e => e.TeacherId)
                })
                .ToListAsync();
            foreach (var item in studentHaveLecture)
            {
                var teacher1 = await _context.Teachers.Where(e => e.Id == item.TeacherId).Include(e => e.Subject).FirstOrDefaultAsync();
                //var teacher2 = new Teacher();
                //teacher2.Id = teacher1.Id;
                teachers.Add(teacher1);
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = teachers.Count;
            return Ok(r);
        }
        [HttpGet("TeachersForStudent/{studentId}")]
        public async Task<ActionResult<int>> GetStudentTeachers(int studentId)
        {
            DateTime timeNow = DateTime.Now;
            List<Teacher> teachers = new List<Teacher>();
            var studentHaveLecture = await _context.StudentHaveLectures
                .Where(e => e.StudentId == studentId)
                .GroupBy(x => x.TeacherId)
                .Select(x => new StudentHaveLecture()
                {
                    StudentId = x.Max(e => e.TeacherId),
                    TeacherId = x.Max(e => e.TeacherId)
                })
                .ToListAsync();
            foreach (var item in studentHaveLecture)
            {
                var teacher1 = await _context.Teachers.Where(e => e.Id == item.TeacherId).Include(e => e.Subject).FirstOrDefaultAsync();
                //var teacher2 = new Teacher();
                //teacher2.Id = teacher1.Id;
                //teacher2.Email = teacher1.Email;
                //teacher2.Fullname = teacher1.Fullname;
                //teacher2.ImageUrl = teacher1.ImageUrl;
                //teacher2.Password = teacher1.Password;
                //teacher2.Percentage = teacher1.Percentage;
                //teacher2.PhoneNumber = teacher1.PhoneNumber;
                //teacher2.School = teacher1.School;
                //teacher2.Subject = teacher1.Subject;
                teachers.Add(teacher1);
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = teachers;
            return Ok(r);

        }
        [HttpPost("IsLectureValid")]
        //[AllowAnonymous]
        public async Task<ActionResult<bool>> isLectureValid(ByingLecture byingLecture)
        {
            DateTime timeNow = DateTime.Now;
            var studentHaveLecture = await _context.StudentHaveLectures.Where(e => e.StudentId == byingLecture.StudentId && 
            e.LectureId == byingLecture.LectureId &&
            timeNow > e.Startdate &&
            timeNow < e.Enddate
            ).FirstOrDefaultAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            if(studentHaveLecture == null)
            {
                r.data = false;
            }
            else
            {
                r.data = true;
            }
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
