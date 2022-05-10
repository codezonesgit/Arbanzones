using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class ServiceProblem
    {
        public string Id { get; set; }
        public int ServiceItemId { get; set; }
        public DateTime? DateOfAvailibility { get; set; }
        public decimal? Amount { get; set; }
        public string UserId { get; set; }
    }
}