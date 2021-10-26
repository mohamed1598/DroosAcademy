using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DroosAcademy.Models;
using DroosAcademy.Models_For_Requests;
namespace DroosAcademy.CommonMethod
{
    public interface IJwtAuthenticationManager
    {
        public Response authenticateAdmin(string username, string password, DroosAcademyContext _context);
        public Response authenticateTeacher(string username, string password, DroosAcademyContext _context);
        public Response authenticateStudent(string username, string password, DroosAcademyContext _context);
        public Response authenticateSeller(string username, string password, DroosAcademyContext _context);

    }
}
