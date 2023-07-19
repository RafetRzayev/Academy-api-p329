using Academy.AuthenticationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.AuthenticationService.Contracts
{
    public interface IAuthService
    {
        Task<string> CreateToken(TokenRequestModel model);
    }
}
