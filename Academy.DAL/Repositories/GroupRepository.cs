using Academy.DAL.DataContext;
using Academy.DAL.Entities;
using Academy.DAL.Repositories.Contracts;
using System;

namespace Academy.DAL.Repositories
{
    public class GroupRepository : EfCoreRepositoryAsync<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
