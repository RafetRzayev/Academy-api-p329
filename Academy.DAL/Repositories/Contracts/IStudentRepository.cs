using Academy.DAL.Entities;

namespace Academy.DAL.Repositories.Contracts
{
    public interface IStudentRepository : IRepositoryAsync<Entities.Student>
    {
        Task<ICollection<Entities.Student>> Test();
    }
}
