//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Extrupet.DAL.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompanySetup
    {
        public byte CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public System.DateTime LastUpdatedOnUTC { get; set; }
        public int LastUpdatedBy { get; set; }
    
        public virtual UserMaster UserMaster { get; set; }
    }
}