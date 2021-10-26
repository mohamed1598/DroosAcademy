using DroosAcademy.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DroosAcademy.Models_For_Requests;
namespace DroosAcademy.CommonMethod
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        //private readonly DroosAcademyContext _context = new DroosAcademyContext();
        private readonly string key;
        public JwtAuthenticationManager(string key)
        {
            //_context = context;
            this.key = key;
        }
        public Response authenticateAdmin(string username, string password, DroosAcademyContext _context)
        {
            var admin = _context.Admins.Where(e => e.Name == username && e.Password == password).FirstOrDefault();
            string s = "";
            if (admin == null)
            {
                return null;
            }
            s += admin.Id;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, s),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.Now.AddMonths(1),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Response r = new Response();
            r.message = "تم تسجيل الدخول إلى الحساب بنجاح";
            r.data = admin;
            r.token = tokenHandler.WriteToken(token);
            return r;
        }
        public Response authenticateTeacher(string username, string password, DroosAcademyContext _context)
        {
            Teacher teacher;
            if (ValidateEmail(username))
            {
                teacher = _context.Teachers.Where(e => e.Email == username && e.Password == password).FirstOrDefault();
            }
            else
            {
                teacher = _context.Teachers.Where(e => e.PhoneNumber == username && e.Password == password).FirstOrDefault();
            }
            string s = "";
            if (teacher == null)
            {
                return null;
            }
            s += teacher.Id;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, teacher.Fullname),
                    new Claim(ClaimTypes.NameIdentifier, s),
                    new Claim(ClaimTypes.Role, "teacher")
                }),
                Expires = DateTime.Now.AddMonths(1),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Response r = new Response();
            r.message = "تم تسجيل الدخول إلى الحساب بنجاح";
            r.data = teacher;
            r.token = tokenHandler.WriteToken(token);
            return r;
        }
        public Response authenticateStudent(string username, string password, DroosAcademyContext _context)
        {
            Student student;
            if (ValidateEmail(username))
            {
                student = _context.Students.Where(e => e.Email == username && e.Password == password).FirstOrDefault();
            }
            else
            {
                student = _context.Students.Where(e => e.PhoneNumber == username && e.Password == password).FirstOrDefault();
            }
            string s = "";
            if (student == null)
            {
                return null;
            }
            s += student.Id;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, student.Fullname),
                    new Claim(ClaimTypes.NameIdentifier, s),
                    new Claim(ClaimTypes.Role, "student")
                }),
                Expires = DateTime.Now.AddMonths(1),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Response r = new Response();
            r.message = "تم تسجيل الدخول إلى الحساب بنجاح";
            r.data = student;
            r.token = tokenHandler.WriteToken(token);
            return r;
        }
        public Response authenticateSeller(string username, string password, DroosAcademyContext _context)
        {
            Seller seller;
            if (ValidateEmail(username))
            {
                seller = _context.Sellers.Where(e => e.Email == username && e.Password == password).FirstOrDefault();
            }
            else
            {
                seller = _context.Sellers.Where(e => e.PhoneNumber == username && e.Password == password).FirstOrDefault();
            }

            string s = "";
            if (seller == null)
            {
                return null;
            }
            s += seller.Id;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, seller.Fullname),
                    new Claim(ClaimTypes.NameIdentifier, s),
                    new Claim(ClaimTypes.Role, "seller")
                }),
                Expires = DateTime.Now.AddMonths(1),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Response r = new Response();
            r.message = "تم تسجيل الدخول إلى الحساب بنجاح";
            r.data = seller;
            r.token = tokenHandler.WriteToken(token);
            return r;
        }
        public static bool ValidateEmail(string str)
        {
            return Regex.IsMatch(str, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }
    }
}
