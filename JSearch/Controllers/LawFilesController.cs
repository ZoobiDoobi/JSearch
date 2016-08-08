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
        JSearchEntities db = new JSearchEntities();
        // GET: LawFiles
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FileForm(int id)
        {
            var judges = db.Judges.ToList();
            var courts = db.Courts.ToList();
            var sections = db.Sections.OrderByDescending(s => s.SectionDateTimeStamp).ToList();

            LawFilesViewModel lawFilesViewModel = new LawFilesViewModel() { Courts = courts, Judges = judges,Sections = sections };
            return View(lawFilesViewModel);
        }

        [HttpPost]
        public ActionResult FileForm(HttpPostedFileBase file, LawFilesViewModel lawFilesViewModel,int id)
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
            var maxFileId = db.LawFiles.Max(f => f.FileId) + 1;
            var newFile = new LawFile()
            {
                FileId = maxFileId,
                FileCode = "F-" + maxFileId,
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

            var fileSectionMaxId = db.FileSections.Max(fs => fs.FileSectionId) + 1;

            var sectionFile = new FileSection()
            {
                FileSectionId = fileSectionMaxId,
                FileSectionCode = "FS-" + fileSectionMaxId,
                FileId = maxFileId,
                FSDateTimeStamp = DateTime.Now,
                //SectionId = lawFilesViewModel.SelectedSection,
                SectionId = id,
                TerminalName = Environment.MachineName,
                UserId = User.Identity.GetUserId()
            };
            db.LawFiles.Add(newFile);
            db.FileSections.Add(sectionFile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}