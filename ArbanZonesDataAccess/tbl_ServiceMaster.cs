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
    
    public partial class tbl_ServiceMaster
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string EntryBy { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
    }
}
