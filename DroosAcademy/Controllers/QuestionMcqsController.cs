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
    public class QuestionMcqsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public QuestionMcqsController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/QuestionMcqs
        [HttpPost("Pagination")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<QuestionMcq>>> GetQuestionMcqs(paginationRequest pr)
        {
            List<QuestionMcq> questionMcqs = await _context.QuestionMcqs.ToListAsync();
            List<QuestionMcq> questionMcqsPaging = questionMcqs.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = questionMcqsPaging;
            return Ok(r);
        }

        // GET: api/QuestionMcqs/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,teacher,student")]
        public async Task<ActionResult<QuestionMcq>> GetQuestionMcq(int id)
        {
            var questionMcq = await _context.QuestionMcqs.FindAsync(id);

            if (questionMcq == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = questionMcq;
            return Ok(r);
        }

        // PUT: api/QuestionMcqs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PutQuestionMcq(int id, QuestionMcq questionMcq)
        {
            if (id != questionMcq.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionMcq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionMcqExists(id))
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
            r.data = questionMcq;
            return Ok(r);
        }

        // POST: api/QuestionMcqs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<QuestionMcq>> PostQuestionMcq(QuestionMcq questionMcq)
        {
            _context.QuestionMcqs.Add(questionMcq);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء اجابات اسئلة الامتحان بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/QuestionMcqs/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> DeleteQuestionMcq(int id)
        {
            var questionMcq = await _context.QuestionMcqs.FindAsync(id);
            if (questionMcq == null)
            {
                return NotFound();
            }

            _context.QuestionMcqs.Remove(questionMcq);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة اجابات اسئلة الامتحان بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool QuestionMcqExists(int id)
        {
            return _context.QuestionMcqs.Any(e => e.Id == id);
        }
    }
}
