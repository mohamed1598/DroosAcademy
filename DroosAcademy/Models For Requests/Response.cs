using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroosAcademy.Models_For_Requests
{
    public class Response
    {
        public string message { get; set; }
        public dynamic data { get; set; }
        public string token { get; set; }
    }
}
