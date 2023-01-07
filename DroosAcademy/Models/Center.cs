using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class Center
    {
        public Center()
        {
            Sellers = new HashSet<Seller>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
