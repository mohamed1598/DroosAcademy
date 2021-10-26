using DroosAcademy.Models;
using DroosAcademy.Models_For_Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroosAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,teacher")]
    public class PriceController : ControllerBase
    {
        private readonly DroosAcademyContext _context;
        public PriceController(DroosAcademyContext context)
        {
            _context = context;
        }
        // Get: api/Price/Today
        [HttpGet("Today/{id}")]
        public async Task<ActionResult<int>> PriceToday(int id)
        {
            DateTime timenow = DateTime.Now;
            //int total = 0;
            DateTime startOfTheDay = new DateTime(timenow.Year, timenow.Month, timenow.Day, 0, 0, 0);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.Startdate >= startOfTheDay && e.Startdate <= timenow)
                .Include(e=>e.Lecture)
                .SumAsync(e=>e.Lecture.Cost);
            Teacher teacher = await _context.Teachers.FindAsync(id);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            double balanceForTeacher = (double)s * (100 - (double)teacher.Percentage) / 100.0;
            double BalanceForPlatform = (double)s * (double)teacher.Percentage / 100.0;
            r.data = new { balanceForTeacher=balanceForTeacher,BalanceForPlatform= BalanceForPlatform };
            return Ok(r);
        }
        // Get: api/Price/Yesterday
        [HttpGet("Yesterday/{id}")]
        public async Task<ActionResult<int>> PriceYesterday(int id)
        {
            DateTime timenow = DateTime.Now;
            DateTime endOfTheDay = new DateTime(timenow.Year, timenow.Month, timenow.Day, 0, 0, 0);
            DateTime startOfTheDay = endOfTheDay.AddDays(-1);
            Teacher teacher = await _context.Teachers.FindAsync(id);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.Startdate >= startOfTheDay && e.Startdate <= endOfTheDay)
                .Include(e => e.Lecture)
                .SumAsync(e => e.Lecture.Cost);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            double balanceForTeacher = (double)s * (100 - (double)teacher.Percentage) / 100.0;
            double BalanceForPlatform = (double)s * (double)teacher.Percentage / 100.0;
            r.data = new { balanceForTeacher = balanceForTeacher, BalanceForPlatform = BalanceForPlatform };
            return Ok(r);
        }
        // Get: api/Price/ThisMonth
        [HttpGet("ThisMonth/{id}")]
        public async Task<ActionResult<int>> PriceThisMonth(int id)
        {
            DateTime timenow = DateTime.Now;
            DateTime startOfTheMonth = new DateTime(timenow.Year, timenow.Month, 1, 0, 0, 0);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.Startdate >= startOfTheMonth && e.Startdate <= timenow )
                .Include(e => e.Lecture)
                .SumAsync(e => e.Lecture.Cost);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            Teacher teacher = await _context.Teachers.FindAsync(id);
            double balanceForTeacher = (double)s * (100 - (double)teacher.Percentage) / 100.0;
            double BalanceForPlatform = (double)s * (double)teacher.Percentage / 100.0;
            r.data = new { balanceForTeacher = balanceForTeacher, BalanceForPlatform = BalanceForPlatform };
            return Ok(r);
        }
        // Get: api/Price/LastMonth
        [HttpGet("LastMonth/{id}")]
        public async Task<ActionResult<int>> PriceLastMonth(int id)
        {
            DateTime timenow = DateTime.Now;
            DateTime endOfTheDay = new DateTime(timenow.Year, timenow.Month, 1, 0, 0, 0);
            DateTime startOfTheDay = endOfTheDay.AddMonths(-1);
            var s = await _context.StudentHaveLectures.Where(e => e.TeacherId == id && e.Startdate >= startOfTheDay && e.Startdate <= endOfTheDay )
                .Include(e => e.Lecture)
                .SumAsync(e => e.Lecture.Cost);
            Response r = new Response();
            r.message = "تم تنفيذ العملية بنجاح";
            Teacher teacher = await _context.Teachers.FindAsync(id);
            double balanceForTeacher = (double)s * (100 - (double)teacher.Percentage) / 100.0;
            double BalanceForPlatform = (double)s * (double)teacher.Percentage / 100.0;
            r.data = new { balanceForTeacher = balanceForTeacher, BalanceForPlatform = BalanceForPlatform };
            return Ok(r);
        }
    }
}
