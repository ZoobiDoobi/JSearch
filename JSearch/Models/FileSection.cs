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
    
    public partial class FileSection
    {
        public int FileSectionId { get; set; }
        public string FileSectionCode { get; set; }
        public Nullable<int> SectionId { get; set; }
        public Nullable<int> FileId { get; set; }
        public string UserId { get; set; }
        public string TerminalName { get; set; }
        public Nullable<int> FileSectionStatus { get; set; }
        public Nullable<System.DateTime> FSDateTimeStamp { get; set; }
    }
}
