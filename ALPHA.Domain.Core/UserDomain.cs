using ALPHA.Domain.Entity;
using ALPHA.Domain.Interface;
using ALPHA.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALPHA.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _Repository;
        public IConfiguration Configuration { get; }

        public UserDomain(IUserRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(User model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(User model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<User> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }

        public async Task<User> getLogin(User model)
        {
            return await _Repository.getLogin(model);
        }
    }
}
