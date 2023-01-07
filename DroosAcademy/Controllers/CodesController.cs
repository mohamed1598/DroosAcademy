using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroosAcademy.Models;
using Microsoft.EntityFrameworkCore;
using DroosAcademy.CommonMethod;
using Microsoft.AspNetCore.Authorization;
using DroosAcademy.Models_For_Requests;

namespace DroosAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CodesController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        public CodesController(DroosAcademyContext context)
        {
            _context = context;
        }
        // GET: api/Codes
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Code>>> GetCodes()
        {
            List<Code> codes = await _context.Codes.ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = codes;
            return Ok(r);
        }

        // GET: api/Codes/5
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Code>> GetCode(int id)
        {
            var Code = await _context.Codes.FindAsync(id);

            if (Code == null)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = Code;
            return Ok(r);
        }

        // PUT: api/Codes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutAdmin(int id, Code code)
        {
            if (id != code.Id)
            {
                return BadRequest();
            }

            _context.Entry(code).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = code;
            return Ok(r);
        }

        // POST: api/Codes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Code>> PostCode(Code code)
        {
            _context.Codes.Add(code);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء الكود بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/Codes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCode(int id)
        {
            var code = await _context.Codes.FindAsync(id);
            if (code == null)
            {
                return NotFound();
            }

            _context.Codes.Remove(code);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة الكود بنجاح";
            r.data = null;
            return Ok(r);
        }
        //return one code
        //api/Codes/5
        [HttpGet("getOneCode/{lectureId}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<Code>> getCode(int lectureId)
        {
            Code c = createCode(lectureId);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = c;
            return Ok(r);
        }
        //return List of codes
        //api/Codes/5
        [HttpPost("getListOfCodes")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<List<Code>>> getListOfCodes(CodeNumbers codenumber)
        {
            List<Code> c = new List<Code>();
            for (int i = 0; i < codenumber.numberOfCodes; i++)
            {
                c.Add(createCode(codenumber.lectureId));
            }
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = c;
            return Ok(r);
        }
        //get teacher number of codes
        //api/Codes/5
        [HttpGet("getTeacherNumberOfCodes/{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<int>> getTeacherNumberOfCodes(int id)
        {
            List<Code> c = await _context.Codes.Where(e => e.TeacherId == id).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = c.Count;
            return Ok(r);
        }
        //get teacher number of deactivated codes
        //api/Codes/5
        [HttpGet("getTeacherNumberOfDeactivatedCodes/{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<int>> getTeacherNumberOfDeactivatedCodes(int id)
        {
            List<Code> c = await _context.Codes.Where(e => e.TeacherId == id && e.Status == false).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = c.Count;
            return Ok(r);
        }
        //get teacher number of activated codes
        //api/Codes/5
        [HttpGet("getTeacherNumberOfActivatedCodes/{id}")]
        [Authorize(Roles = "admin,teacher")]
        public async Task<ActionResult<int>> getTeacherNumberOfActivatedCodes(int id)
        {
            List<Code> c = await _context.Codes.Where(e => e.TeacherId == id && e.Status == true).ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = c.Count;
            return Ok(r);
        }
        //activate codes
        //ActivateLecture
        [HttpPost("ActivateCode")]
        [Authorize(Roles = "student")]
        public async Task<ActionResult<Lecture>> activateLecture(StudentCode s)
        {
            Code code = await _context.Codes.FirstOrDefaultAsync(e => e.Name == s.code);
            if (code.Status != true)
            {
                code.Status = true;
                code.ActivatedDate = DateTime.Now;
                Lecture lecture = await _context.Lectures.FindAsync(code.LectureId);
                StudentHaveLecture studentHaveLecture = new StudentHaveLecture();
                studentHaveLecture.LectureId = code.LectureId;
                studentHaveLecture.StudentId = s.StudentId;
                studentHaveLecture.TeacherId = code.TeacherId;
                studentHaveLecture.Startdate = DateTime.Now;
                if (lecture.LimitedHours != null)
                {
                    studentHaveLecture.Enddate = DateTime.Now.AddHours((int)lecture.LimitedHours);
                }
                studentHaveLecture.Balance = lecture.Cost;
                _context.StudentHaveLectures.Add(studentHaveLecture);
                await _context.SaveChangesAsync();
                Response r = new Response();
                r.message = "تم تنفيذ العملية بنجاح";
                r.data = null;
                return Ok(r);
            }
            return BadRequest();
        }
        public static string GenerateRandomAlphanumericString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyqzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
        private Code createCode(int lectureId)
        {
            string code = GenerateRandomAlphanumericString(7);
            while (CodeExists(code))
            {
                code = GenerateRandomAlphanumericString(7);
            }
            Lecture lecture = _context.Lectures.Find(lectureId);
            Code c = new Code();
            c.LectureId = lecture.Id;
            c.TeacherId = lecture.TeacherId;
            c.YearId = lecture.Yearid;
            c.Name = code;
            c.Status = false;
            c.CreateDate = DateTime.Now;
            _context.Codes.Add(c);
            _context.SaveChanges();
            return c;
        }
        private bool CodeExists(string name)
        {
            return _context.Codes.Any(e => e.Name == name);
        }
    }
}
