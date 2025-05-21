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
    public class StudentManagerController : ControllerBase
    {
        IGradeManagement _gradeManagement;
        IPasswordManagement _passwordManagement;
        GradeManager _gradeManager;
        PasswordManager _passwordManager;
        ILogger<StudentManagerController> _logger;
        IStudents _students;

        public StudentManagerController(ILogger<StudentManagerController> logger, IGradeManagement gradeManagement, IPasswordManagement passwordManagement, IOptions<GradeManager> gradeManager, IOptions<PasswordManager> passwordManager, IStudents students)
        {
            _gradeManagement = gradeManagement;
            _passwordManagement = passwordManagement;
            _logger = logger;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
            _gradeManager = gradeManager.Value;
            _passwordManager = passwordManager.Value;
            _students = students;
        }
        [HttpGet("Show")]
        public Student ShowStudent(string id){
            _logger.LogInformation($"Student {id}'s details had shown successfully");
            return _students.Show(id);
        }

        [HttpGet]
        public List<Student> AllStudent()
        {
            _logger.LogInformation($"Show all the students' details");
           return _students.ShowAllStudents();
        }

        [HttpPost("Add")]
        public void AddStudent([FromQuery][Bind("ID", "Name")] M_Student m_student)
        {
            Student student = m_student.Convert();
            _students.AddStudent(student.Name, student.ID);
            _logger.LogInformation($"Student with id: {student.ID} added successfully!");
        }

        [HttpPut("Update")]
        public void Update(string id, string name)
        {
            _students.EditStudent(id, name);
            _logger.LogInformation($"Updated name to student:{id} to: {name}");
        }

        [HttpDelete("Delete")]
        public void Delete(string id)
        {
            _students.RemoveStudent(id);
            _logger.LogInformation($"The student {id} Deleted");
        }


    }
}



