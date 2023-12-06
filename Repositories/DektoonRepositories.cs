using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace Dektoon.Repositories
{
    public class DektoonRepositories : IDektoonRepositories
    {
        private readonly string ConnectionStrings;

        public DektoonRepositories(string ConnectionStrings)
        {
            this.ConnectionStrings = ConnectionStrings;
        }

        private T WithConnection<T>(Func<IDbConnection, T> getData)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionStrings))
                {
                    connection.Open();
                    return getData(connection);
                }
            }

            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ExecuteStoredProcedure<T>(string spName, DynamicParameters dynamicParameters)
        {
            return WithConnection(c => c.Execute(spName, dynamicParameters, commandType: CommandType.StoredProcedure));
        }

        public IEnumerable<T> QueryStoredProcedure<T>(string spName, DynamicParameters dynamicParameters)
        {
            return WithConnection(c => c.Query<T>(spName, dynamicParameters, commandType: CommandType.StoredProcedure));
        }
    }
}