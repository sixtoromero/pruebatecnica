using Dapper;
using ALPHA.Domain.Entity;
using ALPHA.InfraStructure.Interface;
using ALPHA.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ALPHA.InfraStructure.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ALPHA.InfraStructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextOptions<ALPHADataContext> options;

        public UserRepository(DbContextOptions<ALPHADataContext> options = null)
        {            
            this.options = options;
        }

        public async Task<string> InsertAsync(User model)
        {
            using (var context = new ALPHADataContext(this.options))
            {
                try
                {
                    model.Date = new DateTime();
                    context.Users.Add(model);

                    await context.SaveChangesAsync();

                    return "Success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }                
            }
        }

        public async Task<string> UpdateAsync(User model)
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

        /// <summary>
        /// Al eliminar se debe cambiar al estado D, de Eliminado.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<string> DeleteAsync(int? Id)
        {
            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
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

        public async Task<IEnumerable<User>> GetAllAsync()
        {

            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    return await context.Users.ToListAsync();                    
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> GetAsync(int? Id)
        {
            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    return await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> getLogin(User model)
        {
            try
            {
                using (var context = new ALPHADataContext(this.options))
                {
                    return await context.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
