using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Dtos.Group
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
        public List<int>? TeacherIds { get; set; }   
    }
}
