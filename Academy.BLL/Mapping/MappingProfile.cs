using Academy.BLL.Dtos.Student;
using Academy.DAL.Entities;
using AutoMapper;

namespace Academy.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ForMember(x => x.GroupName, y => y.MapFrom(x => x.Group.Name)).ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();
        }
    }
}
