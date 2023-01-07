using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class Lecture
    {
        public Lecture()
        {
            Codes = new HashSet<Code>();
            Exams = new HashSet<Exam>();
            LectureFolders = new HashSet<LectureFolder>();
            LectureParts = new HashSet<LecturePart>();
            StudentHaveLectures = new HashSet<StudentHaveLecture>();
        }

        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public float? Time { get; set; }
        public int? Cost { get; set; }
        public bool? Published { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool? Limited { get; set; }
        public int? LimitedHours { get; set; }
        public int? Views { get; set; }
        public int? SpecialViews { get; set; }
        public int? Yearid { get; set; }
        public int? SubjectId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ScholageYear Year { get; set; }
        public virtual ICollection<Code> Codes { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<LectureFolder> LectureFolders { get; set; }
        public virtual ICollection<LecturePart> LectureParts { get; set; }
        public virtual ICollection<StudentHaveLecture> StudentHaveLectures { get; set; }
    }
}
