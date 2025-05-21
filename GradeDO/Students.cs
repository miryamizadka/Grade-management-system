using GradeDO.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public class Students : IStudents
    {

        DataSource studentsList = new DataSource();

        public Students()
        {
            studentsList.Initialize();

        }
        public void AddStudent(string id, string name)
        {

            if (studentsList.Students.Any(stu => stu.ID == id))
                throw new StudentAlradyExistException(id);

            studentsList.Students.Add(new Student() { ID = id, Name = name });

        }
        public void RemoveStudent(String id)
        {
            for (int i = 0; i < studentsList.Students.Count; i++)
            {

                if (studentsList.Students[i].ID == id)
                {
                    studentsList.Students.Remove(studentsList.Students[i]);
                    return;
                }
                throw new StudentNotExistException(id);
            }
        }

        public void EditStudent(string id, string name)
        {
            for (int i = 0; i < studentsList.Students.Count; i++)
            {

                if (studentsList.Students[i].ID == id)
                {
                    studentsList.Students[i].Name = name;
                    return;
                }

                throw new StudentNotExistException(id);
            }

        }
        public Student Show(String id)
        {
            for (int i = 0; i < studentsList.Students.Count; i++)
            {

                if (studentsList.Students[i].ID == id)
                    return studentsList.Students[i];
            }
            throw new StudentNotExistException(id);
        }
        public List<Student> ShowAllStudents()
        {
            List<Student> list = new List<Student>();
            list = studentsList.Students;
            return list;


        }
        public void AddGradeToStudent(string StudentId, Grade grade)
        {
            Student student = studentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if (student == null)
                throw new StudentNotExistException(StudentId);
            grade.Date = DateTime.Today;
            student.ExeList.Add(grade);
        }
        public void GradesToStudents(List<Grade> grades, List<Student> students)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                Update(students[i].ID, grades[i]);
            }

        }
        public void Update(string id, Grade grade)
        {
            for (int i = 0; i < studentsList.Students.Count; i++)
            {
                if (studentsList.Students[i].ID == id)
                {
                    for (int j = 0; j < studentsList.Students[i].ExeList.Count; j++)
                    {
                        if (studentsList.Students[i].ExeList[j].ExeNumber == grade.ExeNumber)
                        {
                            studentsList.Students[i].ExeList[j] = grade;
                            return;
                        }

                    }
                }
            }
            AddGradeToStudent(id, grade);
        }
        public Grade getGrade(string id, int code)
        {
            for (int i = 0; i < studentsList.Students.Count; i++)
            {
                if (studentsList.Students[i].ID == id)
                {
                    if (code == 99)
                    {
                        return studentsList.Students[i].TestGrade;
                    }
                    for (int j = 0; j < studentsList.Students[i].ExeList.Count; j++)
                    {
                        if (studentsList.Students[i].ExeList[j].ExeNumber == code)
                        {
                            return studentsList.Students[i].ExeList[j];

                        }

                    }
                }
            }
            throw new GradeNotExistException(code);
        }
        public void InsertGrade(int code, List<string> idList, List<int> grads)
        {
            bool b = false, d = false;
            for (int i = 0; i < idList.Count; i++)
            {
                for (int j = 0; j < studentsList.Students.Count; j++)
                {
                    if (studentsList.Students[j].ID == idList[i])
                    {
                        d = true;
                        for (int k = 0; k < studentsList.Students[j].ExeList.Count; k++)
                        {
                            if (studentsList.Students[j].ExeList[k].ExeNumber == code)
                            {
                                studentsList.Students[j].ExeList[k].GradeNumber = grads[i];
                                b = true;
                            }

                        }
                        if (!b)
                        {
                            Grade grade = new Grade() { ExeNumber = code, Date = DateTime.Now, GradeNumber = grads[i], Comment = "You did it excellent!!" };

                            AddGradeToStudent(idList[i], grade);
                        }
                        b = false;
                    }
                }
                if (!d)
                {
                    throw new StudentNotExistException(idList[i]);
                }
                d = false;

            }

        }

        public List<int> ShowSpecificGrade(int code)
        {
            List<int> grades = new List<int>();

            for (int i = 0; i < studentsList.Students.Count; i++)
            {
                if (code == 99)
                {
                    grades.Add(studentsList.Students[i].TestGrade.GradeNumber);
                }
                else
                {
                    for (int j = 0; j < studentsList.Students[i].ExeList.Count; j++)
                    {
                        if (studentsList.Students[i].ExeList[j].ExeNumber == code)
                        {
                            grades.Add(studentsList.Students[i].ExeList[j].GradeNumber);
                        }
                    }
                }

            }

            return grades;
        }

        public Dictionary<int, List<int>> ShowAllGrade()
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int j = 0; j < studentsList.Students[0].ExeList.Count; j++)
            {
                dict.Add(studentsList.Students[0].ExeList[j].ExeNumber, ShowSpecificGrade(studentsList.Students[0].ExeList[j].ExeNumber));
            }

            return dict;
        }

        public Grade WantedGrade(string id, string pass, int code = 0)
        {
            Grade grade = null;
            DateTime date = DateTime.MinValue;
            for (int i = 0; i < studentsList.Students.Count; i++)
            {

                if (studentsList.Students[i].ID == id)
                {
                    if (!(studentsList.Students[i].Password == pass))
                    {
                        throw new StudentInCorrectPassException(pass);
                    }
                    for (int j = 0; j < studentsList.Students[i].ExeList.Count; j++)
                    {
                        if (code == 0)
                        {
                            if (studentsList.Students[i].ExeList[j].Date > date)
                            {
                                date = studentsList.Students[i].ExeList[j].Date;
                                grade = studentsList.Students[i].ExeList[j];
                            }

                        }

                        else if (studentsList.Students[i].ExeList[j].ExeNumber == code)
                        {
                            return studentsList.Students[i].ExeList[j];
                        }



                    }
                }
            }
            if (grade != null && code == 0)
            {
                return grade;
            }
            throw new GradeNotExistException(code);

        }

        public Grade TestGrade(string id, string pass)
        {
            for (int i = 0; i < studentsList.Students.Count; i++)
            {

                if (studentsList.Students[i].ID == id)
                {
                    if (!(studentsList.Students[i].Password == pass))
                    {
                        throw new StudentInCorrectPassException(pass);
                    }
                }
                return studentsList.Students[i].TestGrade;
            }
            throw new StudentNotExistException(id);
        }

    }
}

