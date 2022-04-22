using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArbanZones.Models
{
    public class UserDetails
    {
        [JsonIgnore]
        public string RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int UserRole { get; set; }
        [Required]
        public string Password { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public DateTime? EntryDate { get; set; }
        [JsonIgnore]
        public DateTime? ModifyDate { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}