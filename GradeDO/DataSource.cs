using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    internal class DataSource
    {
        public List<Student> Students;
        public void Initialize()
        {
            Students = new List<Student>();
            Students.Add(new Student() { ID = "11111111", Name = "Sara", Password = "11111111" });
            Students.Add(new Student() { ID = "22222222", Name = "Rivka", Password = "22222222" });
            Students.Add(new Student() { ID = "33333333", Name = "Rachel", Password = "33333333" });

            Students[0].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, GradeNumber = 100, Comment = "Grate", Date = new DateTime(2020, 8, 20)});
            Students[1].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, GradeNumber = 90, Comment = "Grate", Date = new DateTime(2020, 7, 20) });
            Students[2].ExeList.Add(new Grade() { Name = "Controller", ExeNumber = 1, GradeNumber = 80, Comment = "You can do better", Date = new DateTime(2020, 9, 20) });

            Students[0].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, GradeNumber = 99, Comment = "Grate", Date = new DateTime(2022, 9, 20) });
            Students[1].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, GradeNumber = 76, Comment = ":(", Date = new DateTime(2026, 8, 22) });
            Students[2].ExeList.Add(new Grade() { Name = "ModelBigning", ExeNumber = 2, GradeNumber = 90, Comment = "Good", Date = new DateTime(2022, 12, 22) });

            Students[0].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, GradeNumber = 92, Comment = "Nice", Date = new DateTime(2024, 11, 24) });
            Students[1].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, GradeNumber = 80, Comment = ":(", Date = new DateTime(2025, 10, 25) });
            Students[2].ExeList.Add(new Grade() { Name = "ModelVlidation", ExeNumber = 3, GradeNumber = 100, Comment = "!!!", Date = new DateTime(2023, 9, 23) });

            Students[0].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, GradeNumber = 99, Comment = "Good", Date = new DateTime(2021, 1, 21) };
            Students[1].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, GradeNumber = 99, Comment = "Good" , Date = new DateTime(2019, 3, 19) };
            Students[2].TestGrade= new Grade() { Name = "Tets", ExeNumber = 99, GradeNumber = 99, Comment = "Good" , Date = new DateTime(2024, 9, 20) };
        }
    }
}
