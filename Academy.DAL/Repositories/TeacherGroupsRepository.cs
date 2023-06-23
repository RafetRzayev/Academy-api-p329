using Academy.DAL.DataContext;
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DAL.Repositories
{
    public class TeacherGroupsRepository : EfCoreRepositoryAsync<TeacherGroups>, ITeacherGroupRepository
    {
        public TeacherGroupsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
