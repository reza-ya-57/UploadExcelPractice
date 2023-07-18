
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExcelReader.Data
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnectionString");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);


    }
}
