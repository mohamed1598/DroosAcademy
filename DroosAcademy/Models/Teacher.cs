using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Codes = new HashSet<Code>();
            Exams = new HashSet<Exam>();
            Lectures = new HashSet<Lecture>();
            StudentHaveLectures = new HashSet<StudentHaveLecture>();
            StudentTeacherBalances = new HashSet<StudentTeacherBalance>();
            TeachingYears = new HashSet<TeachingYear>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Governorate { get; set; }
        public string School { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public int? SubjectId { get; set; }
        public string ImageUrl { get; set; }
        public int? Percentage { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Code> Codes { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<StudentHaveLecture> StudentHaveLectures { get; set; }
        public virtual ICollection<StudentTeacherBalance> StudentTeacherBalances { get; set; }
        public virtual ICollection<TeachingYear> TeachingYears { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
