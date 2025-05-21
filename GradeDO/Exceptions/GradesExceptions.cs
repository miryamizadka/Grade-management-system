using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO.Exceptions
{
    public class GradeNotExistException : Exception
    {
        public int StatusCode { get; }

        
        public GradeNotExistException(int code) : base($"The grade with code {code} does not exist")
        {
            StatusCode = 999;
        }
    }

}
