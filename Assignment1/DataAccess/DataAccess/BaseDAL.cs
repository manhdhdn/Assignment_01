
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DataAccess.DataAccess
{
    public class BaseDAL
    {
        public StockDataProvider DataProvider { get; set; } = null!;
        public SqlConnection connection = null!;

        public BaseDAL()
        {
            var connectionString = GetConnectionString();
            DataProvider = new StockDataProvider(connectionString);
        }

        private static string GetConnectionString()
        {
            string connectionString;

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            connectionString = config["ConnectionStrings:SqlServer"];

            return connectionString;
        }

        public void CloseConnection() => StockDataProvider.CloseConnection(connection);
    }
}
