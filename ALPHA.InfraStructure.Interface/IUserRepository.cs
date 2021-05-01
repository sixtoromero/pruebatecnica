using ALPHA.Domain.Entity;
using System.Threading.Tasks;

namespace ALPHA.InfraStructure.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> getLogin(User model);
    }    
}
