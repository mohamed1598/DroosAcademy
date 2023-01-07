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
    [Authorize]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly DroosAcademyContext _context;

        public TransactionsController(DroosAcademyContext context)
        {
            _context = context;
        }

        // GET: api/Transactions
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
        {
            List<Transaction> transactions = await _context.Transactions.ToListAsync();
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = transactions;
            return Ok(r);
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            r.data = transaction;
            return Ok(r);
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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
            r.data = transaction;
            return Ok(r);
        }

        // POST: api/Transactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Transaction>> PostTransaction(Transaction transaction)
        {
            transaction.TransactionDate = DateTime.Now;
            _context.Transactions.Add(transaction);
            StudentTeacherBalance studentTeacherBalance = await _context.StudentTeacherBalances.FirstOrDefaultAsync(e => e.TeacherId == transaction.TeacherId && e.StudentId == transaction.StudentId && e.YearId == transaction.YearId);
            if (studentTeacherBalance == null)
            {
                studentTeacherBalance = new StudentTeacherBalance();
                studentTeacherBalance.StudentId = transaction.StudentId;
                studentTeacherBalance.YearId = transaction.YearId;
                studentTeacherBalance.TeacherId = transaction.TeacherId;
                studentTeacherBalance.Balance = transaction.Balance;
                _context.StudentTeacherBalances.Add(studentTeacherBalance);
            }
            else
            {
                studentTeacherBalance.Balance += transaction.Balance;
            }
            Student s = await _context.Students.FindAsync(transaction.StudentId);
            s.Balance += transaction.Balance;
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم إنشاء بنجاح";
            r.data = null;
            return Ok(r);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            Response r = new Response();
            r.message = "تم ازالة بنجاح";
            r.data = null;
            return Ok(r);
        }
        // Post: api/Transactions/BuyLecture
        [HttpPost("BuyLecture")]
        [Authorize(Roles = "admin,student")]
        public async Task<ActionResult<Transaction>> BuyLecture(ByingLecture byingLecture)
        {
            Lecture lecture = await _context.Lectures.FindAsync(byingLecture.LectureId);
            StudentTeacherBalance studentTeacherBalance = await _context.StudentTeacherBalances.FirstOrDefaultAsync(e =>
                e.YearId == lecture.Yearid &&
                e.TeacherId == lecture.TeacherId &&
                e.StudentId == byingLecture.StudentId);
            Student s = await _context.Students.FindAsync(byingLecture.StudentId);
            Response r = new Response();
            if (studentTeacherBalance != null && studentTeacherBalance.Balance >= lecture.Cost)
            {
                StudentHaveLecture studentHaveLecture = new StudentHaveLecture();
                studentHaveLecture.LectureId = byingLecture.LectureId;
                studentHaveLecture.StudentId = byingLecture.StudentId;
                studentHaveLecture.TeacherId = lecture.TeacherId;
                studentHaveLecture.Startdate = DateTime.Now;
                if (lecture.LimitedHours != null && lecture.Limited == true)
                {
                    studentHaveLecture.Enddate = DateTime.Now.AddHours((int)lecture.LimitedHours);
                }
                if (lecture.Limited == false)
                {
                    studentHaveLecture.Enddate = DateTime.Now.AddMonths(5);
                }
                studentHaveLecture.Balance = lecture.Cost;
                studentTeacherBalance.Balance -= lecture.Cost;
                s.Balance -= lecture.Cost;
                _context.StudentHaveLectures.Add(studentHaveLecture);
                await _context.SaveChangesAsync();
                r.message = "تم ازالة السنتر بنجاح";
                r.data = lecture;
                return Ok(r);
            }
            r.message = "لا تمتلك الرصيد الكافى لشراء هذه المحاضرة";
            r.data = null;
            return Ok(r);
        }
        private bool TransactionExists(int id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
