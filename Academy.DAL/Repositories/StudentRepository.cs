using Academy.DAL.DataContext;
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Academy.DAL.Repositories
{
    public class StudentRepository : EfCoreRepositoryAsync<Entities.Student>, IStudentRepository
    {
        private readonly AppDbContext _dbContext;
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ICollection<Entities.Student>> Test()
        {
            var result = (await base.GetAllAsync()).Where(x => x.Age > 20).ToList();

            return result;
        }

        public override async Task<ICollection<Entities.Student>> GetAllAsync()
        {
            var result = await _dbContext.Students.Include(x => x.Group).ToListAsync();

            return result;
        }

        public override Task AddAsync(Entities.Student entity)
        {
            return base.AddAsync(entity);
        }

        public override Task<Student> GetAsync(int? id)
        {
            var result = _dbContext.Students.AsNoTracking().Include(x => x.Group).FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
