using ALPHA.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALPHA.Domain.Interface
{
    public interface ICorrespondenceDomain : IDomain<Correspondence>
    {
        Task<IEnumerable<Correspondence>> GetAsyncByUserId(int UserId);
    }
}
