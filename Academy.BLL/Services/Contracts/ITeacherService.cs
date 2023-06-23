using Academy.BLL.Dtos.Teacher;

namespace Academy.BLL.Services.Contracts
{
    public interface ITeacherService
    {
        Task<ICollection<TeacherDto>> GetTeachersAsync();
        Task<TeacherDto> GetTeacherAsync(int id);
        Task CreateTeacher(TeacherCreateDto dto);
        Task UpdateTeacher(TeacherUpdateDto dto);
        Task DeleteTeacher(int id);
    }
}
