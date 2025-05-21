
namespace Project.Services
{
    public interface IGradeManagement
    {
        double CalcAvgByCode(int code);
        int CalcFinalGrade(string studentID);
        public int CalcFinalGrade(string studentID, string pass);
        List<string> CalcFinalGrades();
    }
}