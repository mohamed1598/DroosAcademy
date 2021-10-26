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
    public class LecturePartsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public LecturePartsController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/LectureParts
        [HttpPost("Pagination")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<LecturePart>>> GetLectureParts(paginationRequest pr)
        {
            List<LecturePart> lectureParts = await _context.LectureParts.ToListAsync();
            List<LecturePart> lecturesPaging = lectureParts.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lecturesPaging;
            return Ok(r);
        }

        // GET: api/LectureParts/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,teacher,student")]
        public async Task<ActionResult<LecturePart>> GetLecturePart(int id)
        {
            var lecturePart = await _context.LectureParts.FindAsync(id);

            if (lecturePart == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lecturePart;
            return Ok(r);
        }

        // PUT: api/LectureParts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PutLecturePart(int id, LecturePart lecturePart)
        {
            if (id != lecturePart.Id)
            {
                return BadRequest();
            }

            _context.Entry(lecturePart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturePartExists(id))
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
            r.data = lecturePart;
            return Ok(r);
        }

        // POST: api/LectureParts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        //[AllowAnonymous]
        public async Task<ActionResult<LecturePart>> PostLecturePart(LecturePart lecturePart)
        {
            _context.LectureParts.Add(lecturePart);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء فيديو المحاضرة بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/LectureParts/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> DeleteLecturePart(int id)
        {
            var lecturePart = await _context.LectureParts.FindAsync(id);
            if (lecturePart == null)
            {
                return NotFound();
            }

            _context.LectureParts.Remove(lecturePart);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة فيديو المحاضرة بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool LecturePartExists(int id)
        {
            return _context.LectureParts.Any(e => e.Id == id);
        }
    }
}
