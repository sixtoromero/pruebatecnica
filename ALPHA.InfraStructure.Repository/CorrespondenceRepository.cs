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
    public class CorrespondenceRepository : ICorrespondenceRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public CorrespondenceRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> InsertAsync(Correspondence model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCorrespondencesInsert";
                var parameters = new DynamicParameters();
                
                parameters.Add("Type", model.Type);
                parameters.Add("SenderId", model.SenderId);
                parameters.Add("AddresseeId", model.AddresseeId);
                parameters.Add("Subject", model.Subject);
                parameters.Add("Body", model.Body);
                parameters.Add("UserId", model.UserId);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> UpdateAsync(Correspondence model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCorrespondencesUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("Id", model.Id);                
                parameters.Add("Type", model.Type);
                parameters.Add("SenderId", model.SenderId);
                parameters.Add("AddresseeId", model.AddresseeId);
                parameters.Add("Subject", model.Subject);
                parameters.Add("Body", model.Body);
                parameters.Add("UserId", model.UserId);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspCorrespondencesDelete";
                var parameters = new DynamicParameters();

                parameters.Add("Id", Id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Correspondence>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCorrespondences";
                var result = await connection.QueryAsync<Correspondence>(query, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<IEnumerable<Correspondence>> GetAsyncByUserId(int UserId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCorrespondencesByUserId";
                var parameters = new DynamicParameters();
                parameters.Add("UserId", UserId);                
                var result = await connection.QueryAsync<Correspondence>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<Correspondence> GetAsync(int? Id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetCorrespondenceByID";
                var parameters = new DynamicParameters();

                parameters.Add("Id", Id);

                var result = await connection.QuerySingleAsync<Correspondence>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
