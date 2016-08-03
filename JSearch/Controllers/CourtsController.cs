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
    public class CourtsController : Controller
    {
        JSearchContext context = new JSearchContext();
        // GET: Courts
        public ActionResult Index()
        {
            var courts = context.Courts.Where(c => c.CourtStatus == 1).ToList();
            return View(courts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourtsViewModel courtsViewModel)
        {
            if (ModelState.IsValid)
            {
                var maxId = context.Courts.Max(m => m.CourtId) + 1;
                var userId = User.Identity.GetUserId();
                var court = new Court()
                {
                    CourtId = maxId,
                    CourtCode = "C-" + maxId,
                    CourtName = courtsViewModel.CourtName,
                    CourtRemarks = courtsViewModel.CourtRemarks,
                    CourtStatus = courtsViewModel.CourtStatus,
                    CourtDateTimeStamp = DateTime.Now,
                    UserId = userId,
                    TerminalName = Environment.MachineName
                };

                context.Courts.Add(court);
                context.SaveChanges();
                return RedirectToAction("Create");
            }
            else
            {
                return View(courtsViewModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var court = context.Courts.Find(id);
            if (court == null)
            {
                return HttpNotFound();
            }
            var courtViewModel = new CourtsViewModel()
            {
                CourtId = court.CourtId,
                CourtName = court.CourtName,
                CourtRemarks = court.CourtRemarks,
                CourtStatus = court.CourtStatus
            };
            return View(courtViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourtsViewModel courtsViewModel)
        {
            var court = context.Courts.Find(courtsViewModel.CourtId);
            if (ModelState.IsValid)
            {
                court.CourtName = courtsViewModel.CourtName;
                court.CourtRemarks = courtsViewModel.CourtRemarks;
                court.CourtStatus = courtsViewModel.CourtStatus;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtsViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var court = context.Courts.Find(id);
            if (court == null)
            {
                return HttpNotFound();
            }
            CourtsViewModel courtViewModel = new CourtsViewModel()
            {
                CourtId = id,
                CourtName = court.CourtName,
                CourtRemarks = court.CourtRemarks,
                CourtStatus = court.CourtStatus
            };
            return View(courtViewModel);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var court = context.Courts.Find(id);
            court.CourtStatus = 0;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}