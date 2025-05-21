using GradeDO;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Project.Models
{
    public class M_Student
    {
        [Required]
        public string ID { get; set; }

        [MaxLength(20), Required]
        public string Name { get; set; }
        
        public Student Convert()
        {
            return new Student() { ID = ID, Name = Name, Password = ID ,ExeList = new List<Grade>()};
        }

    }
}
