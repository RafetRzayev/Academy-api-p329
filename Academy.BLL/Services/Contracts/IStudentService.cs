using Academy.BLL.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Services.Contracts
{
    public interface IStudentService
    {
        Task<ICollection<StudentDto>> GetStudents();
        Task<StudentDto> GetStudent(int? id);
        Task CreateStudent(StudentCreateDto dto);
        Task<ICollection<StudentDto>> Test();

    }
}
