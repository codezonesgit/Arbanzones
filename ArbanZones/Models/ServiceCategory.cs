using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class ServiceCategory
    {
        public string ServiceCategryName { get; set; }
        public string NoOfBookingsPerYear { get; set; }
        public string Rating { get; set; }
        public List<Banner> banners { get; set; }
        public List<ServiceMaster> servicesList { get; set; }

    }
}