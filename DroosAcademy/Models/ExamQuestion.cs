using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class ExamQuestion
    {
        public ExamQuestion()
        {
            QuestionMcqs = new HashSet<QuestionMcq>();
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public int? Orders { get; set; }
        public int? CorrectAnswer { get; set; }
        public int? ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual ICollection<QuestionMcq> QuestionMcqs { get; set; }
    }
}
