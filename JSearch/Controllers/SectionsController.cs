using JSearch.Models;
using JSearch.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace JSearch.Controllers
{
    [Authorize]
    public class SectionsController : Controller
    {
        private readonly JSearchEntities _db = new JSearchEntities();
        // GET: Sections
        public ActionResult Index()
        {
            var sections = _db.Sections.Where(s => s.SectionStatus == 1).OrderByDescending(s => s.SectionDateTimeStamp).ToList();
            return View(sections);
        }
        
        [HttpGet]
        public ActionResult SectionForm(int selectedLawId,int? selectedSection)
        {
            //This Method here returns the view containing the last form "SectionForm" and it is Http
            return View();
        }
        [HttpPost]
        public ActionResult GetSections(LawsViewModel lawsViewModel)
        {
            var sections = _db.Sections.Where(s => s.LawId == lawsViewModel.SelectedLaw).ToList();
            string lawName =
                _db.Laws.Where(l => l.LawId == lawsViewModel.SelectedLaw).Select(l => l.LawTitle).SingleOrDefault();
            ViewBag.LawName = lawName;
            SectionsViewModel sectionsViewModel = new SectionsViewModel() { Sections = sections,SelectedLawId=lawsViewModel.SelectedLaw };
            return View(sectionsViewModel);
        }

        //This action saves the data that is filled in the Last form
        [HttpPost]
        public ActionResult SectionForm(SectionsViewModel sectionViewModel,int selectedLawId,int? selectedSection)
        {
            
                var maxId = _db.Sections.Max(s => s.SectionId) + 1;
                var section = new Section()
                {
                    SectionId = maxId,
                    SectionName = sectionViewModel.SectionName,
                    SectionCode = "S-" + maxId,
                    LawId = selectedLawId,
                    SectionRemarks = sectionViewModel.SectionRemarks,
                    SectionStatus = sectionViewModel.SectionStatus,
                    SectionDateTimeStamp = DateTime.Now,
                    TerminalName = Environment.MachineName,
                    UserId = User.Identity.GetUserId(),
                    SectionRefId = Convert.ToInt32(selectedSection)
                };
                _db.Sections.Add(section);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            var section = _db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            var sectionsViewModel = new SectionsViewModel()
            {
                SectionName =  section.SectionName,
                SectionRemarks =  section.SectionRemarks,
                SectionStatus =  section.SectionStatus
            };
            return View(sectionsViewModel);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var section = _db.Sections.Find(id);
            section.SectionStatus = 0;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var section = _db.Sections.Find(id);
            if (section == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var laws = _db.Laws.ToList();
            var sectionViewModel = new SectionsViewModel()
            {
                SectionName =  section.SectionName,
                SectionRemarks =  section.SectionRemarks,
                SectionStatus = section.SectionStatus,
                SelectedLawId = Convert.ToInt32(section.LawId),
                SelectedSection = Convert.ToInt32(section.SectionRefId) , //test it
                Sections = _db.Sections.Where(s => s.LawId == section.LawId).ToList(),
                Laws = laws
            };
            return View(sectionViewModel);
        }

        [HttpPost]
        public ActionResult Edit(SectionsViewModel sectionsViewModel, int id)
        {
            var section = _db.Sections.Find(id);
            section.SectionName = sectionsViewModel.SectionName;
            section.SectionStatus = sectionsViewModel.SectionStatus;
            section.SectionRemarks = sectionsViewModel.SectionRemarks;
            section.LawId = sectionsViewModel.SelectedLawId;
            section.SectionRefId = sectionsViewModel.SelectedSection;

            _db.Entry(section).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}