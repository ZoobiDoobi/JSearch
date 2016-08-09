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
    [Authorize]
    public class SectionsController : Controller
    {

        JSearchEntities db = new JSearchEntities();
        // GET: Sections
        public ActionResult Index()
        {
            var sections = db.Sections.OrderByDescending(s => s.SectionDateTimeStamp).ToList();
            return View(sections);
        }
        
        [HttpGet]
        public ActionResult SectionForm(int SelectedLawId,int? SelectedSection)
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
        public ActionResult SectionForm(SectionsViewModel sectionViewModel,int SelectedLawId,int? SelectedSection)
        {
            
            var maxId = db.Sections.Max(s => s.SectionId) + 1;

            var section = new Section()
            {
                SectionId = maxId,
                SectionName = sectionViewModel.SectionName,
                SectionCode = "S-" + maxId,
                LawId = SelectedLawId,
                SectionRemarks = sectionViewModel.SectionRemarks,
                SectionStatus = sectionViewModel.SectionStatus,
                SectionDateTimeStamp = DateTime.Now,
                TerminalName = Environment.MachineName,
                UserId = User.Identity.GetUserId(),
                SectionRefId = Convert.ToInt32(SelectedSection)
            };
            db.Sections.Add(section);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}