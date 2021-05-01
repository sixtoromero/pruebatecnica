using ALPHA.Domain.Entity;
using System.Threading.Tasks;

namespace ALPHA.Domain.Interface
{
    public interface IUserDomain : IDomain<User>
    {
        Task<User> getLogin(User model);
    }
}
