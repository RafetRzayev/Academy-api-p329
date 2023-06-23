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
    public class TeacherGroupManager : ITeacherGroupService
    {
        private ITeacherGroupRepository _teacherGroupRepository;

        public TeacherGroupManager(ITeacherGroupRepository teacherGroupRepository)
        {
            _teacherGroupRepository = teacherGroupRepository;
        }

        public async Task CreateRelationAsync(int teacherId, int groupId)
        {
            var teacherGroup = new TeacherGroups
            {
                TeacherId = teacherId,
                GroupId = groupId
            };

            await _teacherGroupRepository.AddAsync(teacherGroup);
        }
    }
}
