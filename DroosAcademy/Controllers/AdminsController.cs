using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DroosAcademy.Models;
using DroosAcademy.CommonMethod;
using Microsoft.AspNetCore.Authorization;
using DroosAcademy.Models_For_Requests;
namespace DroosAcademy.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public AdminsController(DroosAcademyContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        // GET: api/Admins
        [HttpPost("Pagination")]
        public async Task<ActionResult<Response>> GetAdmins(paginationRequest pr)
        {
            List<Admin> admins = await _context.Admins.ToListAsync();
            List<Admin> adminsPaging = admins.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = adminsPaging;
            return Ok(r);
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = admin;
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(r);
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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
            r.data = admin;
            return Ok(admin);
        }

        // POST: api/Admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostAdmin(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
            Response r = new Response();
            Admin a = await _context.Admins.OrderBy(e => e.Id).LastOrDefaultAsync(e => e.Name == admin.Name);
            r.message = "تم إنشاء الحساب بنجاح";
            r.data = a;
            return Ok(r);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة الحساب بنجاح";
            r.data = null;
            return Ok(r);
        }
        //login
        [AllowAnonymous]
        [HttpPost("Authentication")]
        public ActionResult<Response> Login(LoginRequest admin)
        {
            //Admin a = this._context.Admins.FirstOrDefault(e => e.Name == admin.Name && e.Password == admin.Password);
            Response r = jwtAuthenticationManager.authenticateAdmin(admin.userName, admin.password, _context);
            if (r == null)
            {
                return Unauthorized();
            }
            return Ok(r);
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }
    }
}
