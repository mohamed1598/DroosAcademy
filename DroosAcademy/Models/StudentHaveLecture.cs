using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class StudentHaveLecture
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? StudentId { get; set; }
        public int? LectureId { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int? Balance { get; set; }
        public bool? Watched { get; set; }
        public DateTime? WatchedDate { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
