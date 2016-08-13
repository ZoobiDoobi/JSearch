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
    [Authorize]
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
            var judges = db.Judges.OrderByDescending(j => j.JudgeDateTimeStamp).ToList();
            var courts = db.Courts.OrderByDescending(c => c.CourtDateTimeStamp).ToList();
            var sections = db.Sections.OrderByDescending(s => s.SectionDateTimeStamp).ToList();

            LawFilesViewModel lawFilesViewModel = new LawFilesViewModel() { Courts = courts, Judges = judges, Sections = sections };
            return View(lawFilesViewModel);
        }

        [HttpPost]
        public ActionResult FileForm(IEnumerable<HttpPostedFileBase> file, LawFilesViewModel lawFilesViewModel, int id)
        {
            string path = string.Empty;
            foreach (var item in file)
            {
                string filextension = Path.GetExtension(item.FileName);
                if (item != null && item.ContentLength > 0 && filextension == ".pdf")
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Files/"), Path.GetFileName(item.FileName));
                        item.SaveAs(path);
                        ViewBag.Message = "File Uploaded Successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "Error in Uploading Files" + ex.Message;
                        return RedirectToAction("FileForm");
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
                    FilePath = ResolveServerUrl(VirtualPathUtility.ToAbsolute("~/Files/" + Path.GetFileName(path)), false),
                    FileRemarks = lawFilesViewModel.FileRemarks,
                    FileTitle = Path.GetFileNameWithoutExtension(path),
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
                    SectionId = id,
                    TerminalName = Environment.MachineName,
                    UserId = User.Identity.GetUserId()
                };
                db.LawFiles.Add(newFile);
                db.FileSections.Add(sectionFile);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Downloads()
        {
            var dir = new DirectoryInfo(Server.MapPath("~/Files/"));
            FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> filesList = new List<string>();

            foreach (var item in fileNames)
            {
                filesList.Add(item.Name);
            }
            return View(filesList);
        }

        public FileResult Download(string FileName)
        {
            return File(Server.MapPath("~/Files/") + FileName, System.Net.Mime.MediaTypeNames.Application.Pdf);
        }

        public static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
            {
                return serverUrl;
            }

            string newUrl = serverUrl;
            Uri originalUri = System.Web.HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) + "://" + originalUri.Authority + newUrl;
            return newUrl;
        }
    }
}