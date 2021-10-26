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
    public class LecturesController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public LecturesController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/Lectures
        [HttpPost("Pagination")]
        //[Authorize(Roles = "admin")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Lecture>>> GetLectures(paginationRequest pr)
        {
            List<Lecture> lectures = await _context.Lectures.Include(e=>e.Teacher).ToListAsync();
            List<Lecture> lecturesPaging = lectures.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lecturesPaging;
            return Ok(r);
        }

        // GET: api/Lectures/5
        // get lecture by lecture id
        [HttpGet("{id}")]
        [Authorize]
        //[AllowAnonymous]
        public async Task<ActionResult<Lecture>> GetLecture(int id)
        {
            var lecture = await _context.Lectures.Where(e => e.Id == id)
                .Include(e => e.Teacher)
                .Include(e => e.LectureFolders)
                .Include(e => e.LectureParts)
                .Include(e => e.Year)
                .Include(e => e.Subject)
                .Include(e => e.Exams).FirstOrDefaultAsync();

            if (lecture == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lecture;
            return Ok(r);
        }
        // GET: api/Lectures/Teacher/5
        // get lecture by lecture id
        [HttpPost("TeacherLectures")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Lecture>>> GetLectursForTeacher(TeacherLecturesRequest teacherLecturesRequest)
        {
            var teacher = await _context.Teachers
                .Where(e => e.Fullname == teacherLecturesRequest.teacherName)
                .FirstOrDefaultAsync();
            if (teacher == null)
            {
                return Ok(false);
            }
            int x = teacher.Id;
            //var lectures = await _context.Lectures.Where(e => e.TeacherId == x && e.Yearid == teacherLecturesRequest.yearId)
            //    .Include(e => e.Teacher).ToListAsync();
            var lectures = await _context.Lectures.Where(e => e.TeacherId == x )
                .Include(e => e.Teacher).ToListAsync();

            if (lectures == null)
            {
                return Ok(false);
            }
            List<Lecture> lecturesPaging = lectures.Skip((teacherLecturesRequest.skip) * teacherLecturesRequest.limit).Take(teacherLecturesRequest.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lecturesPaging;
            return Ok(r);
        }
        // PUT: api/Lectures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PutLecture(int id, Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return BadRequest();
            }

            _context.Entry(lecture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureExists(id))
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
            r.data = lecture;
            return Ok(r);
        }

        // POST: api/Lectures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        //[AllowAnonymous]
        public async Task<ActionResult<Lecture>> PostLecture(Lecture lecture)
        {
            lecture.PublishedDate = DateTime.Now;
            lecture.Views = 0;
            lecture.SpecialViews = 0;
            _context.Lectures.Add(lecture);
            TeachingYear teachingYear = new TeachingYear();
            teachingYear.TeacherId = lecture.TeacherId;
            teachingYear.YearId = lecture.Yearid;
            if (!_context.TeachingYears.Any(e => e.TeacherId == teachingYear.TeacherId && e.YearId == teachingYear.YearId))
            {
                _context.TeachingYears.Add(teachingYear);
            }
            await _context.SaveChangesAsync();
            Lecture l = await _context.Lectures.OrderBy(e => e.Id).LastOrDefaultAsync(e => e.Name == lecture.Name && e.TeacherId == lecture.TeacherId);
            Response r = new Response();
            r.message = "تم إنشاء المحاضرة بنجاح";
            r.data = l;
            return Ok(r);
        }

        // DELETE: api/Lectures/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> DeleteLecture(int id)
        {
            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }

            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة المحاضرة بنجاح";
            r.data = null;
            return Ok(r);
        }
        private bool LectureExists(int id)
        {
            return _context.Lectures.Any(e => e.Id == id);
        }
    }
}
