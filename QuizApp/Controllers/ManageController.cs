using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Data;
using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [Route("Account/{controller}/Admin/{action=Index}")]
    public class ManageController : Controller
    {
        private readonly QuizContext _db;
        public ManageController(QuizContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var quizzes = await _db.Quizzes.ToListAsync();
            return View(quizzes);
        }

        [HttpGet]
        public IActionResult CreateQuiz()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateQuiz(Quiz quizCreateModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid Data");
                return View(quizCreateModel);
            }

            await _db.Quizzes.AddAsync(quizCreateModel);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<IActionResult> EditQuiz(int Id)
        {
            var quiz = await _db.Quizzes.Include(c => c.Questions)
                .ThenInclude(c => c.Answers)
                .AsSplitQuery()
                .Where(c => c.Id == Id)
                .OrderBy(c => c.Id)
                .FirstAsync();
            return View(quiz);
        }
    }
}
