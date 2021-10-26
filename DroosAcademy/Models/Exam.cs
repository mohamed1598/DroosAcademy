using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamQuestions = new HashSet<ExamQuestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public float? Time { get; set; }
        public DateTime? StartTime { get; set; }
        public int? TeacherId { get; set; }
        public int? LectureId { get; set; }
        public int? YearId { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ScholageYear Year { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    }
}
