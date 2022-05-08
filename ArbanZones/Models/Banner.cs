using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public bool? Active { get; set; }
    }
}