using JSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSearch.ViewModels
{
    public class LawsViewModel
    {
        public IEnumerable<Law> Laws { get; set; }
    }
}