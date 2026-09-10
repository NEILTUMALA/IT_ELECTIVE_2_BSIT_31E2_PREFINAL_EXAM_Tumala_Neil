using System.Text.Json;
using ExamApp.Models;

namespace ExamApp.Services
{
    public class ExamService
    {
        private readonly string _filePath;

        public ExamService(IWebHostEnvironment env)
        {
            _filePath = Path.Combine(env.ContentRootPath, "Data", "questions.json");
        }

        public List<ExamQuestion> GetAllQuestions()
        {
            if (!File.Exists(_filePath)) return new List<ExamQuestion>();

            var jsonContent = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<ExamQuestion>>(jsonContent) ?? new List<ExamQuestion>();
        }
    }
}