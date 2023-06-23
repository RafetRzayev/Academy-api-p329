using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DAL.Entities
{
    public class Teacher : TimeStample
    {
        public string Name { get; set; }
        public string Department { get; set; }

        public ICollection<TeacherGroups> TeacherGroups { get; set; }   
    }
}
