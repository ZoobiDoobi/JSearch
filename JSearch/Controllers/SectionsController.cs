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
        public int SectionRefId { get; set; } //Temporary Implementation

        JSearchContext db = new JSearchContext();
        // GET: Sections
        public ActionResult Index()
        {

            return View();
        }
        
        [HttpGet]
        public ActionResult SectionForm()
        {
            //This Method here returns the view containing the last form "SectionForm" and it is Http
            return View();
        }
        [HttpPost]
        public ActionResult GetSections(LawsViewModel lawsViewModel)
        {
            var sections = db.Sections.Where(s => s.LawId == lawsViewModel.SelectedLaw).ToList();
            SectionsViewModel sectionsViewModel = new SectionsViewModel() { Sections = sections,SelectedLawId=lawsViewModel.SelectedLaw };
            return View(sectionsViewModel);
        }

        //This action saves the data that is filled in the Last form
        [HttpPost]
        public ActionResult Create(SectionsViewModel sectionViewModel)
        {
            var maxId = db.Sections.Max(s => s.SectionId) + 1;

            var section = new Section()
            {
                SectionId = maxId,
                SectionName = sectionViewModel.SectionName,
                SectionCode = "S-" + maxId,
                LawId = sectionViewModel.SelectedLawId,
                SectionRemarks = sectionViewModel.SectionRemarks,
                SectionStatus = sectionViewModel.SectionStatus,
                SectionDateTimeStamp = DateTime.Now,
                TerminalName = Environment.MachineName,
                UserId = User.Identity.GetUserId(),
                SectionRefId = sectionViewModel.SelectedSection
            };
            db.Sections.Add(section);
            db.SaveChanges();

            return RedirectToAction("Create","LawFiles");
        }

    }
}