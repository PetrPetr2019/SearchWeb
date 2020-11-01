using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSearch.Controllers
{
  
    public class SearchController : Controller
    {
        SearchWebContext db= new SearchWebContext();
        public IActionResult Index(string search)
        {
        
        var list = db.Live.ToList();

            return View(db.Live.Where(t=>t.Question.StartsWith(search)
                                         ||t.Answer.StartsWith(search)).ToList());
        }

       
    }
}
