using Academy.DAL.DataContext;
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DAL.Repositories
{
    public class TeacherRepository : EfCoreRepositoryAsync<Teacher>, ITeacherRepository
    {
        private readonly AppDbContext _dbContext;

        public TeacherRepository(AppDbContext dbContext) : base(dbContext)
        {
                _dbContext = dbContext;
        }


        public override async Task<ICollection<Teacher>> GetAllAsync()
        {
            var teachers = await _dbContext.Teachers.Include(x => x.TeacherGroups).ThenInclude(y => y.Group).ToListAsync();

            return teachers;
        }

    }
}
