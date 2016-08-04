using JSearch.Models;
using JSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSearch.Controllers
{
    public class SectionsController : Controller
    {
        JSearchContext db = new JSearchContext();
        // GET: Sections
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(int lawId)
        {
            SectionsViewModel sectionsViewModel = new SectionsViewModel();
            sectionsViewModel.LawId = lawId;
            return View(sectionsViewModel);
        }

        [HttpPost]
        public ActionResult Create(SectionsViewModel sectionViewModel)
        {
            var maxId = db.Sections.Max(s => s.SectionId) + 1;
            return View();
        }

    }
}