using Academy.BLL.Dtos.Student;
using Academy.BLL.Dtos;
using Academy.BLL.Dtos.Group;

namespace Academy.BLL.Services.Contracts
{
    public interface IGroupService
    {
        Task<ICollection<GroupDto>> GetGroups();
        Task<GroupDto> GetGroup(int? id);
        Task CreateGroup(GroupCreateDto dto);
        Task<ResponseModel> DeleteGroup(int id);

        Task UpdateGroup(GroupUpdateDto student);
    }

}
