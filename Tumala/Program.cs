using ExamApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Register the custom ExamService
builder.Services.AddScoped<ExamService>();

var app = builder.Build();

// ... standard middleware setup
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Exam}/{action=Index}/{id?}");

app.Run();