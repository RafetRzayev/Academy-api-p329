using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.BLL.Services.Contracts
{
    public interface ITeacherGroupService
    {
        Task CreateRelationAsync(int teacherId, int groupId);
    }
}
