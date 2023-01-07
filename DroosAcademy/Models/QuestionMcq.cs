using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class QuestionMcq
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public string Answer { get; set; }
        public int? Orders { get; set; }

        public virtual ExamQuestion Question { get; set; }
    }
}
