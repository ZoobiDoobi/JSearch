//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JSearch.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Law
    {
        public int LawId { get; set; }
        public string LawCode { get; set; }
        public string LawTitle { get; set; }
        public string LawRemarks { get; set; }
        public Nullable<int> LawStatus { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> LawDateTimeStamp { get; set; }
        public string TerminalName { get; set; }
    }
}
