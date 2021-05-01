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
    public class ContactDomain : IContactDomain
    {
        private readonly IContactRepository _Repository;
        public IConfiguration Configuration { get; }

        public ContactDomain(IContactRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<string> InsertAsync(Contact model)
        {
            return await _Repository.InsertAsync(model); 
        }

        public async Task<string> UpdateAsync(Contact model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Contact> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }
    }
}
