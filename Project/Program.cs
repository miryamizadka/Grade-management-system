using GradeDO;
using Project.Configuration;
using Project.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.Configure<GradeManager>(builder.Configuration.GetSection("GradeManager"));
builder.Services.Configure<PasswordManager>(builder.Configuration.GetSection("PasswordManager"));
builder.Services.AddSingleton<IStudents, Students>();
builder.Services.AddSingleton<IGradeManagement, GradeManagement>();
builder.Services.AddTransient<IPasswordManagement, PasswordManagement>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
