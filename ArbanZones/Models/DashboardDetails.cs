using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class DashboardDetails
    {
        public string OfferImgUrl { get; set; }
        public List<Banner> banners { get; set; }
        public List<Category> serviceCategory { get; set; }
    }

}