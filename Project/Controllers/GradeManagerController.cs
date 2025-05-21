using GradeDO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Project.Configuration;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeManagerController : ControllerBase
    {

        IGradeManagement _gradeManagement;
        IPasswordManagement _passwordManagement;
        GradeManager _gradeManager;
        PasswordManager _passwordManager;
        ILogger<GradeManagerController> _logger;
        IStudents _students;
        public GradeManagerController(ILogger<GradeManagerController> logger, IGradeManagement gradeManagement, IPasswordManagement passwordManagement, IOptions<GradeManager> gradeManager, IOptions<PasswordManager> passwordManager, IStudents students)
        {
            _gradeManagement = gradeManagement;
            _passwordManagement = passwordManagement;
            _logger = logger;
            _gradeManager = gradeManager.Value;
            _passwordManager = passwordManager.Value;
            _students = students;
        }

        [HttpPut("InsertGrades")]
        public IActionResult InsertGradesToStudent( int code, [FromBody] InsertGrades lists)
        {
            _logger.LogInformation($"Grades inserted successfully for exe number: {code}");
            _students.InsertGrade(code, lists.idList, lists.grades);
            return Ok();
        }

        [HttpPut("Update")]
        public void UpdateGrade(string id,[FromQuery][Bind("ExeNumber", "GradeNumber")] M_Grade m_grade)
        {
            Grade grade = m_grade.Convert();
            _students.Update(id, grade);
            _logger.LogInformation($"The grade in exe number:{grade.ExeNumber} had updated successfully to {grade.GradeNumber} for student: {id}");
        }

        [HttpGet("ShowGrade")]
        public List<int> ShowGrade(int code)
        {
            _logger.LogInformation($"Show grades for exe number: {code}");
            return _students.ShowSpecificGrade(code);
        }

        [HttpGet("CalcGrade")]
        public int FinalGrade(string id)
        {
            _logger.LogInformation($"Final grade for student id: {id} calculated successfully");
            return _gradeManagement.CalcFinalGrade(id);
        }
        [HttpGet]
        public Dictionary<int, List<int>> ShowAll()
        {
            _logger.LogInformation("Show final grades for all the students");
            return _students.ShowAllGrade();
        }
    }
}
