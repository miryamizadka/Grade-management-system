using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO.Exceptions
{
    public class StudentNotExistException : Exception
    {
        public int StatusCode { get; }
        public StudentNotExistException(string StudentId):base($"The student with Id {StudentId} not exist")
        {
            StatusCode = 300;
        }
        
    }
    public class StudentAlradyExistException  : Exception
    {
        public int StatusCode { get; }
        public StudentAlradyExistException(string StudentId) : base($"The student with Id {StudentId} aleady exist")
        {
            StatusCode = 700;
        }

    }

    public class StudentInCorrectPassException : Exception
    {
        public int StatusCode { get; }
        public StudentInCorrectPassException(string pass) : base($"The student with pass {pass} is not correct")
        {
            StatusCode = 400;
        }

    }
}
