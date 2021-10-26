using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroosAcademy.Models_For_Requests
{
    public class TeacherLecturesRequest
    {
        public int skip { get; set; }
        public int limit { get; set; }
        public string teacherName { get; set; }
        public int yearId { get; set; }
    }
}
