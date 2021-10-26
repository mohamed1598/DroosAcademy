using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroosAcademy.Models;
using Microsoft.EntityFrameworkCore;
using DroosAcademy.Models_For_Requests;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DroosAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ViewsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        public ViewsController(DroosAcademyContext context)
        {
            _context = context;
        }
        // POST: api/Lectures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("IncreaseViews")]
        public async Task<ActionResult<int>> IncreaseViews(StudentHaveLecture studentHaveLecture)
        {
            StudentHaveLecture s = await _context.StudentHaveLectures.Where(e => e.StudentId == studentHaveLecture.StudentId && e.LectureId == studentHaveLecture.LectureId).OrderBy(e => e.Id).LastOrDefaultAsync();
            if (s != null)
            {
                Lecture l = await _context.Lectures.FindAsync(s.LectureId);
                if (s.Watched.HasValue == false)
                {
                    l.Views += 1;
                    s.Watched = true;
                    s.WatchedDate = DateTime.Now;
                }

                l.SpecialViews += 1;
                await _context.SaveChangesAsync();
                Response r = new Response();
                r.message = "تم تنفيذ العملية بنجاح";
                r.data = l.Views;
                return Ok(r);
            }
            return BadRequest();
        }
        // Get: api/Views
        [HttpGet("{id}")]
        public async Task<ActionResult<int>> Views(int id)
        {
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.Watched == true).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = s.Count;
            return Ok(r);

        }
        // Get: api/Views/Today
        [HttpGet("Today/{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<int>> ViewsToday(int id)
        {
            DateTime timenow = DateTime.Now;
            DateTime startOfTheDay = new DateTime(timenow.Year, timenow.Month, timenow.Day, 0, 0, 0);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.WatchedDate >= startOfTheDay && e.WatchedDate <= timenow && e.Watched == true).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = s.Count;
            return Ok(r);
        }
        // Get: api/Views/Yesterday
        [HttpGet("Yesterday/{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<int>> ViewsYesterday(int id)
        {
            DateTime timenow = DateTime.Now;
            DateTime endOfTheDay = new DateTime(timenow.Year, timenow.Month, timenow.Day, 0, 0, 0);
            DateTime startOfTheDay = endOfTheDay.AddDays(-1);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.WatchedDate >= startOfTheDay && e.WatchedDate <= endOfTheDay && e.Watched == true).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = s.Count;
            return Ok(r);
        }
        // Get: api/Views/ThisMonth
        [HttpGet("ThisMonth/{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<int>> ViewsThisMonth(int id)
        {
            DateTime timenow = DateTime.Now;
            DateTime startOfTheMonth = new DateTime(timenow.Year, timenow.Month, 1, 0, 0, 0);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.WatchedDate >= startOfTheMonth && e.WatchedDate <= timenow && e.Watched == true).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = s.Count;
            return Ok(r);
        }
        // Get: api/Views/LastMonth
        [HttpGet("LastMonth/{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<int>> ViewsLastMonth(int id)
        {
            DateTime timenow = DateTime.Now;
            DateTime endOfTheDay = new DateTime(timenow.Year, timenow.Month, 1, 0, 0, 0);
            DateTime startOfTheDay = endOfTheDay.AddMonths(-1);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.WatchedDate >= startOfTheDay && e.WatchedDate <= endOfTheDay && e.Watched == true).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = s.Count;
            return Ok(r);
        }

    }
}
