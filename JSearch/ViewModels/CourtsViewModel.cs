using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSearch.ViewModels
{
    public class CourtsViewModel
    {
        public int CourtId { get; set; }
        [Required]
        [Display(Name ="Court Name")]
        public string CourtName { get; set; }

        [Display(Name ="Remarks")]
        public string CourtRemarks { get; set; }

        [Display(Name ="Status")]
        public int? CourtStatus { get; set; }
    }
}