using Academy.DAL.DataContext;
using Academy.DAL.Repositories.Contracts;

namespace Academy.DAL.Repositories
{
    public class StudentRepository : EfCoreRepositoryAsync<Entities.Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {

        }


        public async Task<ICollection<Entities.Student>> Test()
        {
            var result = (await base.GetAllAsync()).Where(x => x.Age > 20).ToList();

            return result;
        }

        public override Task<ICollection<Entities.Student>> GetAllAsync()
        {
            return base.GetAllAsync();
        }

        public override Task AddAsync(Entities.Student entity)
        {
            entity.Age = 50;
            return base.AddAsync(entity);
        }
    }
}
