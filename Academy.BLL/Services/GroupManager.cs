using Academy.BLL.Dtos;
using Academy.BLL.Dtos.Group;
using Academy.BLL.Dtos.Student;
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
    public class GroupManager : IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupManager(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task CreateGroup(GroupCreateDto dto)
        {
            var teacherGroups = new List<TeacherGroups>();

            var group = new Group
            {
                Name = dto.Name,
            };

            dto.TeacherIds.ToList().ForEach(x => teacherGroups.Add(new TeacherGroups
            {
                TeacherId = x,
                GroupId = group.Id
            }));

            group.TeacherGroups = teacherGroups;

            await _groupRepository.AddAsync(group);
        }

        public Task<ResponseModel> DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDto> GetGroup(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<GroupDto>> GetGroups()
        {
            var groups = await _groupRepository.GetAllAsync();

            var groupDtos = new List<GroupDto>();

            foreach (var item in groups)
            {
                groupDtos.Add(new GroupDto
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return groupDtos;
        }

        public Task UpdateGroup(GroupUpdateDto student)
        {
            throw new NotImplementedException();
        }
    }
}
