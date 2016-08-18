using JSearch.Models;
using JSearch.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace JSearch.Controllers
{
    [Authorize]
    public class LawFilesController : Controller
    {
        readonly JSearchEntities _db = new JSearchEntities();
        // GET: LawFiles
        public ActionResult Index()
        {
            var lawFiles = _db.LawFiles.OrderByDescending(l => l.FileDateTimeStamp).ToList();
            return View(lawFiles);
        }

        [HttpGet]
        public ActionResult FileForm(int id)
        {
            var judges = _db.Judges.Where(j => j.JudgeStatus == 1).OrderBy(j => j.JudgeName).ToList();
            var courts = _db.Courts.Where(c => c.CourtStatus == 1).OrderByDescending(c => c.CourtDateTimeStamp).ToList();

            LawFilesViewModel lawFilesViewModel = new LawFilesViewModel() { Courts = courts, Judges = judges };
            return View(lawFilesViewModel);
        }

        [HttpPost]
        public ActionResult FileForm(IEnumerable<HttpPostedFileBase> file, LawFilesViewModel lawFilesViewModel, int id)
        {
            string path = string.Empty;
            foreach (var item in file)
            {
                string filextension = Path.GetExtension(item.FileName);
                if (item.ContentLength > 0 && filextension == ".pdf")
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
                var maxFileId = _db.LawFiles.Max(f => f.FileId) + 1;
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

                var fileSectionMaxId = _db.FileSections.Max(fs => fs.FileSectionId) + 1;

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
                _db.LawFiles.Add(newFile);
                _db.FileSections.Add(sectionFile);
                _db.SaveChanges();
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

        public FileResult Download(string fileName)
        {
            return File(Server.MapPath("~/Files/") + fileName, System.Net.Mime.MediaTypeNames.Application.Pdf);
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

        public ActionResult Edit(int id)
        {
            var judges = _db.Judges.Where(j => j.JudgeStatus == 1).OrderBy(j => j.JudgeName).ToList();
            var courts = _db.Courts.Where(c => c.CourtStatus == 1).OrderByDescending(c => c.CourtDateTimeStamp).ToList();
            var sections =
                _db.Sections.Where(s => s.SectionStatus == 1).OrderByDescending(s => s.SectionDateTimeStamp).ToList();


            var lawFile = _db.LawFiles.Find(id);
            int? fileSectionId = _db.FileSections.Where(f => f.FileId == id).Select(f => f.SectionId).SingleOrDefault();
            if (lawFile == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var lawFileViewModel = new LawFilesViewModel()
            {
                FileTitle = lawFile.FileTitle,
                FileYear =  lawFile.FileYear,
                FileDescription = lawFile.FileDescription,
                FileAbstract = lawFile.FileAbstract,
                FileRemarks = lawFile.FileRemarks,
                SelectedCourt = Convert.ToInt32(lawFile.CourtId),
                SelectedJudge = Convert.ToInt32(lawFile.JudgeId),
                SelectedSection = Convert.ToInt32(fileSectionId),
                Judges = judges,
                Sections = sections,
                Courts = courts
            };
            return View(lawFileViewModel);
        }


        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file,LawFilesViewModel lawFilesViewModel,int id)
        {
            string filextension = Path.GetExtension(file.FileName);
            string path = string.Empty;
                if (file.ContentLength > 0 && filextension == ".pdf")
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Files/"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        ViewBag.Message = "File Edited Successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "Error in Editing File" + ex.Message;
                        return RedirectToAction("Edit");
                    }
                }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }
                var lawFile = _db.LawFiles.Find(id);
                lawFile.CourtId = lawFilesViewModel.SelectedCourt;
                lawFile.JudgeId = lawFilesViewModel.SelectedJudge;
                lawFile.FileAbstract = lawFilesViewModel.FileAbstract;
                lawFile.FileDateTimeStamp = DateTime.Now;
                lawFile.FileDescription = lawFilesViewModel.FileDescription;
                lawFile.FilePath = ResolveServerUrl(VirtualPathUtility.ToAbsolute("~/Files/" + Path.GetFileName(path)), false);
                lawFile.FileRemarks = lawFilesViewModel.FileRemarks;
                lawFile.FileTitle = Path.GetFileNameWithoutExtension(path);
                lawFile.FileYear = lawFilesViewModel.FileYear;
                lawFile.TerminalName = Environment.MachineName;
                lawFile.UserId = User.Identity.GetUserId();

                _db.Entry(lawFile).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            throw new NotImplementedException();
        }
    }
}