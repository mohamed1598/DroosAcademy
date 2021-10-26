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
    public class ExamsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        public ExamsController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/Exams
        [HttpPost("Pagination")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Exam>>> GetExams(paginationRequest pr)
        {
            List<Exam> exams = await _context.Exams.ToListAsync();
            List<Exam> examsPaging = exams.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = examsPaging;
            return Ok(r);
        }

        // GET: api/Exams/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,teacher,student")]
        //[AllowAnonymous]
        public async Task<ActionResult<Exam>> GetExam(int id)
        {
            var exam = await _context.Exams.Where(e => e.Id == id)
                .Include(e => e.ExamQuestions)
                .ThenInclude(e => e.QuestionMcqs)
                .FirstOrDefaultAsync();

            if (exam == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = exam;
            return Ok(r);
        }
        [HttpGet("LectureExams/{id}")]
        //[AllowAnonymous]
        [Authorize]
        public async Task<ActionResult<List<Exam>>> GetLectureExams(int id)
        {
            List<Exam> exams = await _context.Exams.Where(e => e.LectureId == id).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = exams;
            return Ok(r);
        }
        // PUT: api/Exams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PutExam(int id, Exam exam)
        {
            if (id != exam.Id)
            {
                return BadRequest();
            }

            _context.Entry(exam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(id))
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
            r.data = exam;
            return Ok(r);
        }

        // POST: api/Exams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        //[AllowAnonymous]
        public async Task<ActionResult<Exam>> PostExam(Exam exam)
        {
            Lecture lecture = await _context.Lectures.FirstOrDefaultAsync(e => e.Id == exam.LectureId);
            exam.TeacherId = lecture.TeacherId;
            exam.YearId = lecture.Yearid;
            exam.StartTime = DateTime.Now;
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            Exam exam2 = await _context.Exams.OrderBy(e => e.Id).LastOrDefaultAsync(e => e.Name == exam.Name && e.LectureId == exam.LectureId && e.TeacherId == exam.TeacherId);
            Response r = new Response();
            r.message = "تم إنشاء الامتحان بنجاح";
            r.data = exam2;
            return Ok(r);
        }

        // DELETE: api/Exams/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة الامتحان بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.Id == id);
        }
    }
}
