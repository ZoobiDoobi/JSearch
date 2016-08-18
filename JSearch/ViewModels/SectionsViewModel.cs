using JSearch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSearch.ViewModels
{
    public class SectionsViewModel
    {
        public int SelectedLawId { get; set; }

        public int SelectedSection { get; set; }

        [Required]
        [Display(Name ="Section Name")]
        public string SectionName { get; set; }

        [StringLength(300)]
        [Display(Name ="Remarks")]
        public string SectionRemarks { get; set; }

        [Display(Name ="Status")]
        [JStatus]
        public int? SectionStatus { get; set; }

        public IEnumerable<Section> Sections { get; set; }

        public IEnumerable<Law> Laws { get; set; }  


    }
}