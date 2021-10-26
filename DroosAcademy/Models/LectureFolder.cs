using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class LectureFolder
    {
        public int Id { get; set; }
        public int? LectureId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}
