using ALPHA.Application.DTO;
using ALPHA.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALPHA.Application.Interface
{
    public interface IUserApplication : IApplication<UserDTO>
    {
        Task<Response<UserDTO>> getLogin(UserDTO model);
    }
}
