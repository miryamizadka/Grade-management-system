using GradeDO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Project.Configuration;
using Project.Services;
using System.Runtime.Intrinsics.X86;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchingGradeController : ControllerBase
    {

        IGradeManagement _gradeManagement;
        IPasswordManagement _passwordManagement;
        GradeManager _gradeManager;
        PasswordManager _passwordManager;
        ILogger<WatchingGradeController> _logger;
        IStudents _students;
        public WatchingGradeController(ILogger<WatchingGradeController> logger, IGradeManagement gradeManagement, IPasswordManagement passwordManagement, IOptions<GradeManager> gradeManager, IOptions<PasswordManager> passwordManager, IStudents students)
        {
            _gradeManagement = gradeManagement;
            _passwordManagement = passwordManagement;
            _logger = logger;
            _gradeManager = gradeManager.Value;
            _passwordManager = passwordManager.Value;
            _students = students;
        }

        [HttpGet("Last")]
        public string WatchLastGrade(string id, string pass)
        {            
            Grade res = _students.WantedGrade(id, pass);
            double avg = _gradeManagement.CalcAvgByCode(res.ExeNumber);
            _logger.LogInformation($"Watching the last grade for student with id: {id}, password: {pass} has shown successfully!\nLast grade:{res.GradeNumber}, class average for this exe number:{avg}");
            return $"Last grade:{res.GradeNumber}, class average for this exe number:{avg}";
        }

        [HttpGet("Wanted")]
        public string WatcWantedGrade(string id, string pass, int code)
        {            
            double avg = _gradeManagement.CalcAvgByCode(code);
            Grade res = _students.WantedGrade(id, pass, code);
            _logger.LogInformation($"Watching the grades for exe num: {code}, for student with id: {id} password: {pass} has shown successfully!\nWanted grade:{res.GradeNumber}, class average for this exe number:{avg}");
            return $"Wanted grade:{res.GradeNumber}, class average for this exe number:{avg}";
        }

        [HttpGet("TestGrade")]
        public string WatchTestGrade(string id, string pass)
        {
            Grade grade = _students.TestGrade(id, pass);
            double avg = _gradeManagement.CalcAvgByCode(grade.ExeNumber);
            _logger.LogInformation($"Watchint the test grade for student id:{id}, password{pass} has shown successfully!\nTest grade:{grade.GradeNumber}, class average for this exe number:{avg}");
            return $"Test grade:{grade.GradeNumber}, Average:{avg}";
        }
        [HttpGet("FinalGrade")]
        public string WatchFinalGrade(string id, string pass)
        {
            int final = _gradeManagement.CalcFinalGrade(id, pass);
            _logger.LogInformation($"Watchint the final grade for student id:{id}, password{pass} has shown successfully!\n\"Final grade:{final}");
            return $"Final grade:{final}";
        }
    }
}
