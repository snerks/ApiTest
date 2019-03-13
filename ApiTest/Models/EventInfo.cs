using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class EventInfo
    {
        public int Id { get; set; }
        public string Organiser { get; set; }
        public DateTime EventDate { get; set; }
    }
}
