using Dapper;
using ALPHA.Domain.Entity;
using ALPHA.InfraStructure.Interface;
using ALPHA.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ALPHA.InfraStructure.DAL;

namespace ALPHA.InfraStructure.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DbContextOptions<ALPHADataContext> options;

        public ContactRepository(IConnectionFactory connectionFactory)
        {
            this.options = options;
        }

        public async Task<string> InsertAsync(Contact model)
        {
            using (var context = new ALPHADataContext(this.options))
            {
                try
                {
                    model.Date = new DateTime();
                    context.Contacts.Add(model);

                    await context.SaveChangesAsync();

                    return "Success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> UpdateAsync(Contact model)
        {
            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    context.Entry(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public async Task<string> DeleteAsync(int? Id)
        {
            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    var user = await context.Contacts.FirstOrDefaultAsync(x => x.Id == Id);
                    if (user == null)
                    {
                        return "No se encontró el registro";
                    }
                    else
                    {
                        context.Remove(user);
                        await context.SaveChangesAsync();
                    }

                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    return await context.Contacts.ToListAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> GetAsync(int? Id)
        {
            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    return await context.Contacts.FirstOrDefaultAsync(x => x.Id == Id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }        
    }
}
