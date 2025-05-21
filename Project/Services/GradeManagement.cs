using GradeDO;
using GradeDO.Exceptions;
using Microsoft.Extensions.Options;
using Project.Configuration;

namespace Project.Services
{
    public class GradeManagement : IGradeManagement
    {
        private Configuration.GradeManager _gradeManager;
        private IStudents _students;
        private IConfiguration _config;



        public GradeManagement(IOptions<GradeManager> gradeManager, IStudents students, IConfiguration config)
        {
            _students = students;
            _config = config;
            _gradeManager = _config.GetSection("calculate").Get<GradeManager>();
        }

        public int CalcFinalGrade(string studentID, string pass)
        {
            if(!(pass == studentID))
            {
                throw new StudentInCorrectPassException(pass);
            }
            return CalcFinalGrade(studentID);
        }
        public int CalcFinalGrade(string studentID)
        {
            double finalGrade = 0;

            List<int> exerciseNumbers = _config.GetSection("calculate:ExeNumbers").Get<List<int>>();
            List<double> exercisePercentages = _config.GetSection("calculate:Percentege").Get<List<double>>();
            int testNum = _config.GetSection("calculate:TestNumber").Get<int>();
            double testper = _config.GetSection("calculate:TestPercentege").Get<double>();

            foreach (int exerciseNumber in exerciseNumbers)
            {
                var grade = _students.getGrade(studentID, exerciseNumber);
                if (grade != null)
                {
                    finalGrade += grade.GradeNumber * exercisePercentages[exerciseNumbers.IndexOf(exerciseNumber)];
                }
            }
            var testgrade = _students.getGrade(studentID, testNum);
            finalGrade += testgrade.GradeNumber * testper;

            return (int)finalGrade;
        }
        public List<string> CalcFinalGrades()
        {
            List<Student> students = _students.ShowAllStudents();
            List<string> FinalGrades = new List<string>();
            int i = 0;
            foreach (Student student in students)
            {
                FinalGrades.Add("Grade: " + CalcFinalGrade(student.ID) + student.ToString());
            }
            return FinalGrades;
        }
        public double CalcAvgByCode(int code)
        {
            int testNum = _config.GetSection("calculate:TestNumber").Get<int>();
            List<Student> students = _students.ShowAllStudents();
            double total = 0;
            double count = 0;
            for (int i = 0; i < students.Count; i++)
            {
                if(code == testNum)
                {
                    total += students[i].TestGrade.GradeNumber;
                    count++;
                }
                for (int j = 0; j < students[i].ExeList.Count; j++)
                {
                    if (students[i].ExeList[j].ExeNumber == code)
                    {
                        total += students[i].ExeList[j].GradeNumber;
                        count++;
                    }
                }
            }
            return total / count;
        }
    }
}

