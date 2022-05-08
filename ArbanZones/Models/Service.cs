using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public string ServiceProivedId { get; set; }
        public string RegId { get; set; }

        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [JsonIgnore]
        public string EntryBy { get; set; }
        [JsonIgnore]
        public DateTime? EntryDate { get; set; }
    }
}