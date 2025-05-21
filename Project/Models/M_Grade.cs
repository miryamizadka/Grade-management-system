using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using GradeDO;
namespace Project.Models
{
    public class M_Grade
    {
        [Range(1, 99)]
        public int ExeNumber { get; set; }
        public int GradeNumber { get; set; }
        

        public Grade Convert()
        {
            return new Grade() { ExeNumber = ExeNumber ,Name="Exe" , Date=DateTime.Now , GradeNumber=GradeNumber , Comment ="EXCELLENT!!!"  };
        }
        

    }
}
