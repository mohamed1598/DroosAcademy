using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Lectures = new HashSet<Lecture>();
            Teachers = new HashSet<Teacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lecture> Lectures { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
