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
        JSearchContext context = new JSearchContext();
        // GET: Judge
        public ActionResult Index()
        {
            var judges =  context.Judges.Where( m => m.JudgeStatus == 1).ToList();
            return View(judges);
        }

        [HttpGet]
        public ActionResult Edit(int judgeId)
        {
            if (judgeId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Judge judge = context.Judges.Find(judgeId);
            JudgeViewModel judgeViewModel = new JudgeViewModel()
            {
                JudgeId = judgeId,
                JudgeName = judge.JudgeName,
                JudgeRemarks = judge.JudgeRemarks,
                JudgeStatus = judge.JudgeStatus
            };
            if (judge == null)
            {
                return HttpNotFound();
            }
            return View(judgeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JudgeViewModel judgeViewModel)
        {
            if (ModelState.IsValid)
            {
                var judge = context.Judges.Find(judgeViewModel.JudgeId);
                judge.JudgeId = judgeViewModel.JudgeId;
                judge.JudgeName = judgeViewModel.JudgeName;
                judge.JudgeRemarks = judgeViewModel.JudgeRemarks;
                judge.JudgeStatus = judgeViewModel.JudgeStatus;
                context.SaveChanges();
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
            var maxId = context.Judges.Max(j => j.JudgeId) + 1;
            var userId = User.Identity.GetUserId();
            var judge = new Judge()
            {
                JudgeId = maxId,
                JudgeCode = "J"+maxId,
                JudgeName = judgeViewModel.JudgeName,
                JudgeRemarks = judgeViewModel.JudgeRemarks,
                JudgeStatus = judgeViewModel.JudgeStatus,
                JudgeDateTimeStamp = DateTime.Now,
                UserId = userId,
                TerminalName = Environment.MachineName
            };
            context.Judges.Add(judge);
            context.SaveChanges();

            return RedirectToAction("CreateJudge", "Judge");
        }

        [HttpGet]
        public ActionResult Details(int judgeId)
        {
            var judge = context.Judges.Find(judgeId);
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
            var judge = context.Judges.Find(judgeId);
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
            var judge = context.Judges.Find(judgeId);
            judge.JudgeStatus = 0;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}