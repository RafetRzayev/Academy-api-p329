
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;

namespace Academy.DAL.Repositories.Student
{
    public interface IStudentRepository : IRepositoryAsync<Entities.Student>
    {
        Task<ICollection<Entities.Student>> Test();
    }
}
