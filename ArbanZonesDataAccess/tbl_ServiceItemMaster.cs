//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArbanZonesDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ServiceItemMaster
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string ItemTitleName { get; set; }
        public decimal AvgPrice { get; set; }
        public string Image { get; set; }
        public string DecriptionTitle1 { get; set; }
        public string DecriptionTitle2 { get; set; }
        public string Decription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
    }
}
