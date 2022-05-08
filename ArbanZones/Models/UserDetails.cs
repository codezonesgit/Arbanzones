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

        public string RegistrationId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Email address Required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile is Required")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNo { get; set; }

        public int UserRole { get; set; }

        [Required(ErrorMessage = "Mobile is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Mobile is Required")]
        [DataType(DataType.Text)]
        public string DeviceName { get; set; }

        public string DeviceToken { get; set; }
        public DateTime? EntryDate { get; set; }
        [JsonIgnore]
        public DateTime? ModifyDate { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }

        public string UserMessage { get; set; } 
    }
}