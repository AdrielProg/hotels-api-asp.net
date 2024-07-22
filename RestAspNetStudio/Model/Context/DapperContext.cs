using Npgsql;
using System.Data;

namespace RestAspNetStudio.Model.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("PostgreSQLConnectionString");
        }

        public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    }
}