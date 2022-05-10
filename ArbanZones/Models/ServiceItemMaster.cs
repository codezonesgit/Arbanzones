using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class ServiceItemMaster
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceItemName { get; set; }
        public decimal AvgAmount { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


    }
}