using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Dtos.Student
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }    
        public int GroupId { get; set; }
    }
}
