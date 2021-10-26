using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DroosAcademy.Models;
using DroosAcademy.Models_For_Requests;
using Microsoft.AspNetCore.Authorization;

namespace DroosAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScholageYearsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public ScholageYearsController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/ScholageYears
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ScholageYear>>> GetScholageYears()
        {
            List<ScholageYear> scholageYears = await _context.ScholageYears.ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = scholageYears;
            return Ok(r);
        }

        // GET: api/ScholageYears/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ScholageYear>> GetScholageYear(int id)
        {
            var scholageYear = await _context.ScholageYears.FindAsync(id);

            if (scholageYear == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = scholageYear;
            return Ok(r);
        }

        // PUT: api/ScholageYears/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutScholageYear(int id, ScholageYear scholageYear)
        {
            if (id != scholageYear.Id)
            {
                return BadRequest();
            }

            _context.Entry(scholageYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScholageYearExists(id))
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
            r.data = scholageYear;
            return Ok(r);
        }

        // POST: api/ScholageYears
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ScholageYear>> PostScholageYear(ScholageYear scholageYear)
        {
            _context.ScholageYears.Add(scholageYear);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء السنة الدراسية بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/ScholageYears/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteScholageYear(int id)
        {
            var scholageYear = await _context.ScholageYears.FindAsync(id);
            if (scholageYear == null)
            {
                return NotFound();
            }

            _context.ScholageYears.Remove(scholageYear);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة السنة الدراسية بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool ScholageYearExists(int id)
        {
            return _context.ScholageYears.Any(e => e.Id == id);
        }
    }
}
