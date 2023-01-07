using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class ScholageYear
    {
        public ScholageYear()
        {
            Codes = new HashSet<Code>();
            Exams = new HashSet<Exam>();
            Lectures = new HashSet<Lecture>();
            StudentTeacherBalances = new HashSet<StudentTeacherBalance>();
            Students = new HashSet<Student>();
            TeachingYears = new HashSet<TeachingYear>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Code> Codes { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<StudentTeacherBalance> StudentTeacherBalances { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeachingYear> TeachingYears { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
