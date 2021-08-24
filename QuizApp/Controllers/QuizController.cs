using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        [Route("Quiz/{id:int}")]
        [Authorize]
        public IActionResult Index(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}
