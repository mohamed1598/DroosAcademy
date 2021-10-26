using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class StudentTeacherBalance
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }
        public int? YearId { get; set; }
        public int? Balance { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ScholageYear Year { get; set; }
    }
}
