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
        //public int SectionId { get; set; }
        //public int LawId { get; set; }
        public int SelectedSection { get; set; }
        public int SelectedLawId { get; set; }

        [Required]
        [Display(Name ="Section Name")]
        public string SectionName { get; set; }

        [Display(Name ="Remarks")]
        public string SectionRemarks { get; set; }

        [Display(Name ="Status")]
        public int SectionStatus { get; set; }

        public IEnumerable<Section> Sections { get; set; }


    }
}