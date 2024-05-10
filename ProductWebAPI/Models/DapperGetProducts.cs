using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
namespace ProductWebAPI.Models
{
    public class DapperGetProducts
    {
        private readonly string _connectionString;

        public DapperGetProducts(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Product>("GetProducts", commandType: CommandType.StoredProcedure);
                // return connection.Query<Customer>("Select * from Customer");
               // var parameter = new { Id = id };
                //return connection.Query<Product>("GetCustomerById", parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
