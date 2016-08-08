using JSearch.Models;
using JSearch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSearch.Controllers
{
    [Authorize]
    public class LawsController : Controller
    {
        JSearchEntities db = new JSearchEntities();
        // GET: Laws
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult GetLaws()
        {
            var laws = db.Laws.Where(l => l.LawId != 0).ToList();
            LawsViewModel lawsViewModel = new LawsViewModel { Laws = laws };
            return View(lawsViewModel);
        }
    }
}