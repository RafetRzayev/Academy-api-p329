using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DAL.Entities
{
    public class Student : TimeStample
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
