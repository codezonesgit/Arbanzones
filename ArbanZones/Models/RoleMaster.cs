using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class RoleMaster
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
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