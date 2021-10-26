using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class TeachingYear
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int? YearId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ScholageYear Year { get; set; }
    }
}
