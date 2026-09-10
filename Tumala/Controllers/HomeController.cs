using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tumala.Models; // Adjust this namespace if your project uses a different one

namespace Tumala.Controllers
{
    public class ExamItem
    {
        public int Number { get; set; }
        public string Question { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public string Answer { get; set; } = string.Empty;
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var questions = new List<ExamItem>
            {
                new ExamItem { Number = 1, Question = "What is the main problem solved by using a database instead of an in-memory collection?", Options = new() { "A. It makes C# code shorter", "B. It prevents the application from restarting", "C. It allows data to persist after the application stops", "D. It removes the need for MVC" }, Answer = "C. It allows data to persist after the application stops" },
                new ExamItem { Number = 2, Question = "Which approach is being used when an existing database is used to generate EF Core entity classes?", Options = new() { "A. Code-First", "B. Database-First", "C. Model-First", "D. Controller-First" }, Answer = "B. Database-First" },
                new ExamItem { Number = 3, Question = "What is the primary purpose of Entity Framework Core?", Options = new() { "A. To create HTML pages automatically", "B. To replace the MVC Controller", "C. To map objects in code to relational database data", "D. To replace the C# compiler" }, Answer = "C. To map objects in code to relational database data" },
                new ExamItem { Number = 4, Question = "Which EF Core component is primarily responsible for communicating with the database?", Options = new() { "A. DbContext", "B. DbSetView", "C. ControllerContext", "D. RazorContext" }, Answer = "A. DbContext" },
                new ExamItem { Number = 5, Question = "What does the following command primarily do? dotnet ef dbcontext scaffold \"ConnectionString\" Microsoft.EntityFrameworkCore.SqlServer -o Models", Options = new() { "A. Deletes the database", "B. Creates a new MVC project", "C. Generates EF Core models and a DbContext from an existing database", "D. Starts the MVC application" }, Answer = "C. Generates EF Core models and a DbContext from an existing database" },
                new ExamItem { Number = 6, Question = "Where is a database connection string commonly stored in an ASP.NET Core MVC application?", Options = new() { "A. Program.cs only", "B. appsettings.json", "C. Index.cshtml", "D. Student.cs" }, Answer = "B. appsettings.json" },
                new ExamItem { Number = 7, Question = "A Student belongs to exactly one Section, while a Section can contain many students. What type of relationship is this?", Options = new() { "A. One-to-One", "B. One-to-Many", "C. Many-to-Many", "D. Many-to-One only" }, Answer = "B. One-to-Many" },
                new ExamItem { Number = 8, Question = "In the following example, what is SectionId? public int SectionId { get; set; } public Section Section { get; set; }", Options = new() { "A. Primary key of Student", "B. Foreign key referencing Section", "C. Navigation property", "D. Database connection string" }, Answer = "B. Foreign key referencing Section" },
                new ExamItem { Number = 9, Question = "What is the purpose of a navigation property such as public Section Section { get; set; }?", Options = new() { "A. It stores the database password", "B. It represents a relationship to another entity", "C. It creates a new database", "D. It validates the student's name" }, Answer = "B. It represents a relationship to another entity" },
                new ExamItem { Number = 10, Question = "What does .Include() generally allow EF Core to do?", Options = new() { "A. Delete the Section table", "B. Load related Section data together with Students", "C. Create a new Student", "D. Validate Student input" }, Answer = "B. Load related Section data together with Students" },
                new ExamItem { Number = 11, Question = "Why might a ViewModel be used when displaying Student and Section information?", Options = new() { "A. To replace the database", "B. To combine or shape the data specifically needed by the view", "C. To automatically create database tables", "D. To prevent controllers from using LINQ" }, Answer = "B. To combine or shape the data specifically needed by the view" },
                new ExamItem { Number = 12, Question = "Consider this query: var students = _context.Students.Include(s => s.Section).ToList(); What is the main benefit of Include(s => s.Section)?", Options = new() { "A. It loads the related Section navigation property", "B. It creates a Section object manually", "C. It removes the foreign key", "D. It prevents the query from accessing the database" }, Answer = "A. It loads the related Section navigation property" },
                new ExamItem { Number = 13, Question = "Which type of validation occurs in the browser before a request is sent to the server?", Options = new() { "A. Database-level validation", "B. Client-side validation", "C. Server-side validation", "D. EF Core migration validation" }, Answer = "B. Client-side validation" },
                new ExamItem { Number = 14, Question = "Why is server-side validation still necessary if client-side validation exists?", Options = new() { "A. Client-side validation can be bypassed", "B. Client-side validation automatically modifies the database", "C. Server-side validation only works with SQLite", "D. Client-side validation cannot display messages" }, Answer = "A. Client-side validation can be bypassed" },
                new ExamItem { Number = 15, Question = "A school requires every student to have a unique Student Number. Which rule best represents this requirement?", Options = new() { "A. Student Number should always be nullable", "B. Student Number should be unique", "C. Student Number should always be the same", "D. Student Number should contain only spaces" }, Answer = "B. Student Number should be unique" },
                new ExamItem { Number = 16, Question = "Which is the best reason for having a database-level unique constraint on StudentNumber?", Options = new() { "A. It protects data integrity even if application-level validation is bypassed", "B. It makes Razor Views render faster", "C. It removes the need for a Controller", "D. It automatically creates a ViewModel" }, Answer = "A. It protects data integrity even if application-level validation is bypassed" },
                new ExamItem { Number = 17, Question = "What is the purpose of a try...catch block in a controller?", Options = new() { "A. To create navigation properties", "B. To catch and handle exceptions that may occur during execution", "C. To generate database tables", "D. To perform client-side validation" }, Answer = "B. To catch and handle exceptions that may occur during execution" },
                new ExamItem { Number = 18, Question = "Which middleware is commonly used in ASP.NET Core for centralized exception handling?", Options = new() { "A. UseDatabase()", "B. UseExceptionHandler()", "C. UseValidationHandler()", "D. UseMvcDatabase()" }, Answer = "B. UseExceptionHandler()" },
                new ExamItem { Number = 19, Question = "A user requests /Student/999, but Student 999 does not exist. What would be the most appropriate response?", Options = new() { "A. Display the student's information anyway", "B. Display a Not Found (404) response/page", "C. Delete Student 999", "D. Create Student 999 automatically" }, Answer = "B. Display a Not Found (404) response/page" },
                new ExamItem { Number = 20, Question = "A student already belongs to Section A for a particular subject. The application attempts to assign the same student to Section A again. What is the primary concern?", Options = new() { "A. Data integrity", "B. HTML formatting", "C. CSS inheritance", "D. Razor syntax" }, Answer = "A. Data integrity" }
            };

            return View(questions);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}