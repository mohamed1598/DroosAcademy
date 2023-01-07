using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DroosAcademy.Models;
using Microsoft.AspNetCore.Authorization;
using DroosAcademy.CommonMethod;
using DroosAcademy.Models_For_Requests;
namespace DroosAcademy.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public SellersController(DroosAcademyContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        // GET: api/Sellers
        [HttpPost("Pagination")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Response>> GetSellers(paginationRequest pr)
        {
            List<Seller> sellers = await _context.Sellers.ToListAsync();
            List<Seller> adminsPaging = sellers.Skip((pr.skip) * pr.limit).Take(pr.limit).ToList();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = adminsPaging;
            return Ok(r);
        }

        // GET: api/Sellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetSeller(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = seller;
            return Ok(r);
        }

        // PUT: api/Sellers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "seller,admin")]
        public async Task<IActionResult> PutSeller(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            _context.Entry(seller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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
            r.data = seller;
            return Ok(r);
        }

        // POST: api/Sellers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Seller>> PostSeller(Seller seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            Response r = new Response();
            Seller s = await _context.Sellers.OrderBy(e => e.Id).LastOrDefaultAsync(e => e.Email == seller.Email);
            r.message = "تم إنشاء الحساب بنجاح";
            r.data = s;
            return Ok(r);
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "seller,admin")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة الحساب بنجاح";
            r.data = null;
            return Ok(r);
        }
        //login
        [HttpPost("Authentication")]
        [AllowAnonymous]
        public async Task<ActionResult<Response>> Login(LoginRequest seller)
        {
            //Seller s = this._context.Sellers.FirstOrDefault(e => e.PhoneNumber == seller.PhoneNumber && e.Password == seller.Password);
            Response r = jwtAuthenticationManager.authenticateSeller(seller.userName, seller.password, _context);
            if (r == null)
            {
                return Unauthorized();
            }
            return Ok(r);
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.Id == id);
        }
    }
}
