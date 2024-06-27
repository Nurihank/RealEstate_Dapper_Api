using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context //içine bağlantı konfigürasyonu oluşturcaz
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }


        //bağlantımızı oluşturduk
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
                                //sqlConnection üstüne alt+enter yapıp microsoft.data.sqlclient kurduk

    }
}
