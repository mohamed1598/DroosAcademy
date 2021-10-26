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
    public class ExamQuestionsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public ExamQuestionsController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/ExamQuestions
        [HttpPost("Pagination")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<ExamQuestion>>> GetExamQuestions(paginationRequest pr)
        {
            List<ExamQuestion> examQuestions = await _context.ExamQuestions.ToListAsync();
            List<ExamQuestion> examsPaging = examQuestions.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = examsPaging;
            return Ok(r);
        }

        // GET: api/ExamQuestions/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,teacher,student")]
        public async Task<ActionResult<ExamQuestion>> GetExamQuestion(int id)
        {
            var examQuestion = await _context.ExamQuestions.FindAsync(id);

            if (examQuestion == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = examQuestion;
            return Ok(r);
        }

        // PUT: api/ExamQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PutExamQuestion(int id, ExamQuestion examQuestion)
        {
            if (id != examQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(examQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamQuestionExists(id))
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
            r.data = examQuestion;
            return Ok(r);
        }

        // POST: api/ExamQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        //[AllowAnonymous]
        public async Task<ActionResult<ExamQuestion>> PostExamQuestion(ExamQuestion examQuestion)
        {
            _context.ExamQuestions.Add(examQuestion);
            await _context.SaveChangesAsync();
            var questions = await _context.ExamQuestions.OrderBy(e => e.Id).LastOrDefaultAsync(e => e.Orders == examQuestion.Orders && e.Question == examQuestion.Question && e.ExamId == examQuestion.ExamId);
            Response r = new Response();
            r.message = "تم إنشاء اسئلة الامتحان بنجاح";
            r.data = questions;
            return Ok(r);
        }

        // DELETE: api/ExamQuestions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> DeleteExamQuestion(int id)
        {
            var examQuestion = await _context.ExamQuestions.FindAsync(id);
            if (examQuestion == null)
            {
                return NotFound();
            }

            _context.ExamQuestions.Remove(examQuestion);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة اسئلة الامتحان بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool ExamQuestionExists(int id)
        {
            return _context.ExamQuestions.Any(e => e.Id == id);
        }
    }
}
