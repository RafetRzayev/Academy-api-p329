using Academy.BLL.Dtos.Group;
using Academy.BLL.Dtos.Teacher;
using Academy.BLL.Services.Contracts;
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Services
{
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task CreateTeacher(TeacherCreateDto dto)
        {
            var teacher = new Teacher
            {
                Name = dto.Name,
                Department = dto.Department,
            };

            await _teacherRepository.AddAsync(teacher);
        }

        public Task DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherDto> GetTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TeacherDto>> GetTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();

            var teacherDtos = new List<TeacherDto>();
            var groupDtos = new List<GroupDto>();

            foreach (var item in teachers)
            {
                //item.TeacherGroups.ToList().ForEach(x => groupDtos.Add(new GroupDto
                //{
                //    Id = x.GroupId,
                //    Name = x.Group.Name
                //}));

                groupDtos = item.TeacherGroups.Select(x => new GroupDto
                {
                    Id = x.GroupId,
                    Name = x.Group.Name
                }).ToList();

                teacherDtos.Add(new TeacherDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Department = item.Department,
                    Groups = groupDtos
                });

                //groupDtos.Clear();

                //groupDtos = new List<GroupDto>();
            }

            return teacherDtos;
        }

        public Task UpdateTeacher(TeacherUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
