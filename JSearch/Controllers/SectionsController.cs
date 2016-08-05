using JSearch.Models;
using JSearch.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSearch.Controllers
{
    public class SectionsController : Controller
    {
        public int LawId { get; set; } //Temporary Implementation
        public int SectionId { get; set; } //Temporary Implementation

        JSearchContext db = new JSearchContext();
        // GET: Sections
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SectionForm(LawFilesViewModel lawFilesViewModel)
        {
            SectionId = lawFilesViewModel.SelectedSection;
            LawId = lawFilesViewModel.SelectedLaw;
            return View();
        }

        [HttpPost]
        public ActionResult Create(SectionsViewModel sectionViewModel)
        {
            var maxId = db.Sections.Max(s => s.SectionId) + 1;

            var section = new Section()
            {
                SectionId = maxId,
                SectionName = sectionViewModel.SectionName,
                SectionCode = "S-" + maxId,
                LawId = LawId,
                SectionRemarks = sectionViewModel.SectionRemarks,
                SectionStatus = sectionViewModel.SectionStatus,
                SectionDateTimeStamp = DateTime.Now,
                TerminalName = Environment.MachineName,
                UserId = User.Identity.GetUserId(),
                SectionRefId = SectionId
            };

            return RedirectToAction("Create");
        }

    }
}