using Microsoft.AspNetCore.Mvc;
using ExamApp.Services;

namespace ExamApp.Controllers
{
    public class ExamController : Controller
    {
        private readonly ExamService _examService;

        public ExamController(ExamService examService)
        {
            _examService = examService;
        }

        public IActionResult Index(string? search, string? category)
        {
            var questions = _examService.GetAllQuestions();

            if (!string.IsNullOrEmpty(search))
            {
                questions = questions.Where(q => q.Question.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                questions = questions.Where(q => q.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewBag.Categories = _examService.GetAllQuestions()
                                            .Select(q => q.Category)
                                            .Distinct()
                                            .ToList();

            return View(questions);
        }
    }
}