﻿using JSearch.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSearch.ViewModels
{
    public class LawFilesViewModel
    {

        [Required]
        [Display(Name ="Title")]
        public string FileTitle { get; set; }

        [Display(Name ="Description")]
        public string FileDescription { get; set; }

        [Display(Name ="Abstract")]
        public string FileAbstract { get; set; }

        [Display(Name ="Year")]
        public string FileYear { get; set; }

        [Display(Name ="Remarks")]
        public string FileRemarks { get; set; }

        [Display(Name ="Sections")]
        public string SectionName { get; set; }

        public int SelectedJudge { get; set; }
        public int SelectedCourt { get; set; }
        public int SelectedSection { get; set; }
        
        [Display(Name ="Judge")]
        public IEnumerable<Judge> Judges { get; set; }

        public IEnumerable<Court> Courts { get; set; }

        public IEnumerable<Section> Sections { get; set; }
    }
}