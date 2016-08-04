using JSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSearch.ViewModels
{
    public class LawsViewModel
    {
        public int SelectedLaw { get; set; }
        public IEnumerable<Law> Laws { get; set; }
    }
}