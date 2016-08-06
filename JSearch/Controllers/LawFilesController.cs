using JSearch.Models;
using JSearch.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSearch.Controllers
{
    public class LawFilesController : Controller
    {
        JSearchContext db = new JSearchContext();
        // GET: LawFiles
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Create(LawsViewModel lawsViewModel)
        //{
        //    int selectedLawId = lawsViewModel.SelectedLaw;
        //    var sections = db.Sections.Where(s => s.LawId == selectedLawId).ToList();
        //    var lawFileViewModel = new LawFilesViewModel() { Sections = sections,SelectedLaw = selectedLawId };
        //    return View(lawFileViewModel);
        //}

        [HttpGet]
        public ActionResult FileForm()
        {
            var judges = db.Judges.ToList();
            var courts = db.Courts.ToList();

            LawFilesViewModel lawFilesViewModel = new LawFilesViewModel() { Courts = courts, Judges = judges };
            return View(lawFilesViewModel);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, LawFilesViewModel lawFilesViewModel)
        {
            string path = string.Empty;
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    path = Path.Combine(Server.MapPath("~/Files/"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File Uploaded Successfully";
                }
                catch (Exception)
                {
                    ViewBag.Message = "Error in Uploading File";
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            var maxId = db.LawFiles.Max(f => f.FileId) + 1;
            var newFile = new LawFile()
            {
                FileId = maxId,
                FileCode = "F-" + maxId,
                CourtId = lawFilesViewModel.SelectedCourt,
                JudgeId = lawFilesViewModel.SelectedJudge,
                FileAbstract = lawFilesViewModel.FileAbstract,
                FileDateTimeStamp = DateTime.Now,
                FileDescription = lawFilesViewModel.FileDescription,
                FilePath = path,
                FileRemarks = lawFilesViewModel.FileRemarks,
                FileTitle = Path.GetFileName(file.FileName),
                FileYear = lawFilesViewModel.FileYear,
                TerminalName = Environment.MachineName,
                UserId = User.Identity.GetUserId()
            };
            db.LawFiles.Add(newFile);
            db.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}