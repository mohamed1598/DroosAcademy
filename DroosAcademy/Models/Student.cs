using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentHaveLectures = new HashSet<StudentHaveLecture>();
            StudentTeacherBalances = new HashSet<StudentTeacherBalance>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Governorate { get; set; }
        public string School { get; set; }
        public int? CurrentYearId { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public int? Balance { get; set; }
        public int? Bonus { get; set; }
        public string ImageUrl { get; set; }

        public virtual ScholageYear CurrentYear { get; set; }
        public virtual ICollection<StudentHaveLecture> StudentHaveLectures { get; set; }
        public virtual ICollection<StudentTeacherBalance> StudentTeacherBalances { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
