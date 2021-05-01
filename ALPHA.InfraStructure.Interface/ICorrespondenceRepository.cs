using ALPHA.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALPHA.InfraStructure.Interface
{
    public interface ICorrespondenceRepository : IRepository<Correspondence>
    {
        Task<IEnumerable<Correspondence>> GetAsyncByUserId(int UserId);
    }
}
