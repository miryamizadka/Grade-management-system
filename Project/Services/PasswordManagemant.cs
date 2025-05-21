using GradeDO;
using Microsoft.Extensions.Options;
using Project.Configuration;

namespace Project.Services
{
    public class PasswordManagement : IPasswordManagement
    {
        private PasswordManager _teacherManager;
        private IStudents _students;

        public PasswordManagement(IOptions<PasswordManager> teacherManager)
        {
            _teacherManager = teacherManager.Value;
        }

        public bool isValid(string name, int password)
        {
            if (_teacherManager.Name.Equals(name) && _teacherManager.Password == password)
            {
                return true;
            }
            foreach (var student in _students.ShowAllStudents())
            {
                if (student.Name.Equals(name) && student.Password.Equals(password))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
