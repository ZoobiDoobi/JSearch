using JSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JSearch.Controllers
{
    public class SearchController : ApiController
    {
        JSearchEntities db = new JSearchEntities();
        [HttpGet]
        public IHttpActionResult Search(string search)
        {
            var searchResults = db.LawFiles.
                Where(f => f.FileTitle.Contains(search) ||
                      f.FileYear.Contains(search) ||
                      f.FileDescription.Contains(search) ||
                      f.FileAbstract.Contains(search));
            if (searchResults == null)
            {
                return NotFound();
            }
            return Ok(searchResults);
        }
        public IHttpActionResult GetTitles(string search)
        {
            var results = db.LawFiles.Where(f => f.FileTitle.Contains(search));
            return Ok(results);
        }

        [HttpGet]
        public IHttpActionResult Get(string query)
        {
            var lawFiles = db.LawFiles.
                Where(f => f.FileTitle.Contains(query) || 
                      f.FileDescription.Contains(query))
                .ToList();
            return Ok(lawFiles);
        }
    }
}
