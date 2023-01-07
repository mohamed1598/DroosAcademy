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
    public class CentersController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public CentersController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/Centers
        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Center>>> GetCenters()
        {
            List<Center> centers = await _context.Centers.ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = centers;
            return Ok(r);
        }

        // GET: api/Centers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Center>> GetCenter(int id)
        {
            var center = await _context.Centers.FindAsync(id);

            if (center == null)
            {
                return NotFound();
            }

            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = center;
            return Ok(r);
        }

        // PUT: api/Centers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutCenter(int id, Center center)
        {
            if (id != center.Id)
            {
                return BadRequest();
            }

            _context.Entry(center).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenterExists(id))
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
            r.data = center;
            return Ok(r);
        }

        // POST: api/Centers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Center>> PostCenter(Center center)
        {
            _context.Centers.Add(center);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء السنتر بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/Centers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCenter(int id)
        {
            var center = await _context.Centers.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }

            _context.Centers.Remove(center);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة السنتر بنجاح";
            r.data = null;
            return Ok(r);
        }

        private bool CenterExists(int id)
        {
            return _context.Centers.Any(e => e.Id == id);
        }
    }
}
