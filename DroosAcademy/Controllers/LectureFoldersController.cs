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
    public class LectureFoldersController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public LectureFoldersController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/LectureFolders
        [HttpPost("Pagination")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<LectureFolder>>> GetLectureFolders(paginationRequest pr)
        {
            List<LectureFolder> lectureFolders = await _context.LectureFolders.ToListAsync();
            List<LectureFolder> lecturesPaging = lectureFolders.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lecturesPaging;
            return Ok(r);
        }

        // GET: api/LectureFolders/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin,teacher,student")]
        public async Task<ActionResult<LectureFolder>> GetLectureFolder(int id)
        {
            var lectureFolder = await _context.LectureFolders.FindAsync(id);

            if (lectureFolder == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = lectureFolder;
            return Ok(r);
        }

        // PUT: api/LectureFolders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> PutLectureFolder(int id, LectureFolder lectureFolder)
        {
            if (id != lectureFolder.Id)
            {
                return BadRequest();
            }

            _context.Entry(lectureFolder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LectureFolderExists(id))
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
            r.data = lectureFolder;
            return Ok(r);
        }

        // POST: api/LectureFolders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<LectureFolder>> PostLectureFolder(LectureFolder lectureFolder)
        {
            _context.LectureFolders.Add(lectureFolder);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء مرفق المحاضرة بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/LectureFolders/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> DeleteLectureFolder(int id)
        {
            var lectureFolder = await _context.LectureFolders.FindAsync(id);
            if (lectureFolder == null)
            {
                return NotFound();
            }

            _context.LectureFolders.Remove(lectureFolder);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة مرفق المحاضرة بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool LectureFolderExists(int id)
        {
            return _context.LectureFolders.Any(e => e.Id == id);
        }
    }
}
