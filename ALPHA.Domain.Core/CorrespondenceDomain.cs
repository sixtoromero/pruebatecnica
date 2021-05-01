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
    public class CorrespondenceDomain : ICorrespondenceDomain
    {
        private readonly ICorrespondenceRepository _Repository;
        public IConfiguration Configuration { get; }

        public CorrespondenceDomain(ICorrespondenceRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Correspondence model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Correspondence model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Correspondence>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<IEnumerable<Correspondence>> GetAsyncByUserId(int UserId)
        {
            return await _Repository.GetAsyncByUserId(UserId);
        }

        public async Task<Correspondence> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
    }
}
