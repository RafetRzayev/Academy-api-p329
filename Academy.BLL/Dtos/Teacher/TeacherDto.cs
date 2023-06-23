using Academy.BLL.Dtos.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Dtos.Teacher
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public List<GroupDto> Groups { get; set; }
    }
}
