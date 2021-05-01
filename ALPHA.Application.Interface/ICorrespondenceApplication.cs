using ALPHA.Application.DTO;
using ALPHA.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALPHA.Application.Interface
{
    public interface ICorrespondenceApplication : IApplication<CorrespondenceDTO>
    {
        Task<Response<IEnumerable<CorrespondenceDTO>>> GetAsyncByUserId(int UserId);
    }
}
