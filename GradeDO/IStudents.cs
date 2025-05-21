
namespace GradeDO
{
    public interface IStudents
    {
        void AddGradeToStudent(string StudentId, Grade grade);
        void AddStudent(string id, string name);
        void EditStudent(string id, string name);
        Grade getGrade(string id, int code);
        void GradesToStudents(List<Grade> grades, List<Student> students);
        void RemoveStudent(string id);
        Student Show(string id);
        List<Student> ShowAllStudents();
        void Update(string id, Grade grade);
        void InsertGrade(int code, List<string> idList, List<int> grads);
        List<int> ShowSpecificGrade(int code);
        Dictionary<int, List<int>> ShowAllGrade();
        Grade WantedGrade(string id, string pass, int code = 0);
        Grade TestGrade(string id, string pass);
    }
}