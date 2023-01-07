using System;
using System.Collections.Generic;

#nullable disable

namespace DroosAcademy.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int? CenterId { get; set; }
        public bool? Status { get; set; }

        public virtual Center Center { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
