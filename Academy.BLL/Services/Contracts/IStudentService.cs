using Academy.BLL.Dtos;
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
        Task<ResponseModel> DeleteStudent(int id);

        Task UpdateStudent(StudentUpdateDto student);

        Task<ICollection<StudentDto>> Test();

    }
}
