using JSearch.Models;
using JSearch.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace JSearch.Controllers
{
    [Authorize]
    public class JudgesController : Controller
    {
        JSearchEntities db = new JSearchEntities();
        // GET: Judge
        public ActionResult Index()
        {
            var judges =  db.Judges.Where( m => m.JudgeStatus == 1).OrderByDescending(j => j.JudgeDateTimeStamp).ToList();
            return View(judges);
        }

        [HttpGet]
        public ActionResult Edit(int judgeId)
        {
            Judge judge = db.Judges.Find(judgeId);
            if (judge == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            JudgeViewModel judgeViewModel = new JudgeViewModel()
            {
                JudgeId = judgeId,
                JudgeName = judge.JudgeName,
                JudgeRemarks = judge.JudgeRemarks,
                JudgeStatus = judge.JudgeStatus
            };
            return View(judgeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JudgeViewModel judgeViewModel)
        {
            if (ModelState.IsValid)
            {
                var judge = db.Judges.Find(judgeViewModel.JudgeId);
                judge.JudgeId = judgeViewModel.JudgeId;
                judge.JudgeName = judgeViewModel.JudgeName;
                judge.JudgeRemarks = judgeViewModel.JudgeRemarks;
                judge.JudgeStatus = judgeViewModel.JudgeStatus;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(judgeViewModel);
        }

        [HttpGet]
        public ActionResult CreateJudge()
        {
            return View();
        }

        [HttpPost] 
        public ActionResult CreateJudge(JudgeViewModel judgeViewModel)
        {
            if (ModelState.IsValid)
            {
                var maxId = db.Judges.Max(j => j.JudgeId) + 1;
                var userId = User.Identity.GetUserId();
                var judge = new Judge()
                {
                    JudgeId = maxId,
                    JudgeCode = "J" + maxId,
                    JudgeName = judgeViewModel.JudgeName,
                    JudgeRemarks = judgeViewModel.JudgeRemarks,
                    JudgeStatus = judgeViewModel.JudgeStatus,
                    JudgeDateTimeStamp = DateTime.Now,
                    UserId = userId,
                    TerminalName = Environment.MachineName
                };
                db.Judges.Add(judge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(judgeViewModel);
        }

        [HttpGet]
        public ActionResult Details(int judgeId)
        {
            var judge = db.Judges.Find(judgeId);
            if (judge == null)
            {
                return HttpNotFound();
            }
            JudgeViewModel judgeViewModel = new JudgeViewModel()
            {
                JudgeId = judgeId,
                JudgeName = judge.JudgeName,
                JudgeRemarks = judge.JudgeRemarks,
                JudgeStatus = judge.JudgeStatus
            };
            return View(judgeViewModel);
        }
        
        [HttpGet]
        public ActionResult Delete(int judgeId)
        {
            var judge = db.Judges.Find(judgeId);
            if (judge == null)
            {
                return HttpNotFound();
            }
            JudgeViewModel judgeViewModel = new JudgeViewModel()
            {
                JudgeId = judgeId,
                JudgeName = judge.JudgeName,
                JudgeRemarks = judge.JudgeRemarks,
                JudgeStatus = judge.JudgeStatus
            };
            return View(judgeViewModel);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int judgeId)
        {
            var judge = db.Judges.Find(judgeId);
            judge.JudgeStatus = 0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}