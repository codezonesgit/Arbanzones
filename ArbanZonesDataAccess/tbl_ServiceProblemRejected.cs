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
    
    public partial class tbl_ServiceProblemRejected
    {
        public int Id { get; set; }
        public string ServiceProblemId { get; set; }
        public string ServiceProviderId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
    }
}
