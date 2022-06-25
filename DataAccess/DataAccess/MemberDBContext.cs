using BusinessObject;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DataAccess
{
    public class MemberDBContext : BaseDAL
    {
        private static MemberDBContext? instance = null;
        private static readonly object instanceLock = new();
        private MemberDBContext()
        {
        }

        public static MemberDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDBContext();
                    }

                    return instance;
                }
            }
        }

        public static bool Login(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var AdEmail = config["Admin:Email"];
            var AdPassword = config["Admin:Password"];

            if (email == AdEmail && password == AdPassword)
            {
                return true;
            }

            return false;
        }

        public MemberObject GetMember(int memberID, string? email, string? password)
        {
            MemberObject member = null!;
            IDataReader dataReader = null!;
            string SQlSelect;
            var parameters = new List<SqlParameter>();

            try
            {
                if (email != null && password != null)
                {
                    SQlSelect = "SELECT MemberID, MemberName, Email, Password, City, Country FROM Members WHERE Email = @Email AND Password = @Password";
                    parameters.Add(StockDataProvider.CreatePrameter("@Email", 50, email, DbType.String));
                    parameters.Add(StockDataProvider.CreatePrameter("@Password", 20, password, DbType.String));
                }
                else
                {
                    SQlSelect = "SELECT MemberID, MemberName, Email, Password, City, Country FROM Members WHERE MemberID = @MemberID";
                    parameters.Add(StockDataProvider.CreatePrameter("@MemberID", 4, memberID, DbType.Int32));
                }

                dataReader = DataProvider.GetDataReader(SQlSelect, CommandType.Text, out connection, parameters.ToArray());

                if (dataReader.Read())
                {
                    member = new MemberObject()
                    {
                        MemberID = memberID,
                        MemberName = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        City = dataReader.GetString(4),
                        Country = dataReader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }

            return member;
        }

        public void AddNew(MemberObject member)
        {
            try
            {
                MemberObject pro = GetMember(member.MemberID, null, null);

                if (pro == null)
                {
                    string SQLInsert = "INSERT Members values (@MemberID, @MemberName, @Email, @Password, @City, @Country)";
                    var parameters = new List<SqlParameter>
                    {
                        StockDataProvider.CreatePrameter("@MemberID", 4, member.MemberID, DbType.Int32),
                        StockDataProvider.CreatePrameter("@MemberName", 50, member.MemberName, DbType.String),
                        StockDataProvider.CreatePrameter("@Email", 50, member.Email, DbType.String),
                        StockDataProvider.CreatePrameter("@Password", 50, member.Password, DbType.String),
                        StockDataProvider.CreatePrameter("@City", 50, member.City, DbType.String),
                        StockDataProvider.CreatePrameter("@Country", 50, member.Country, DbType.String)
                    };
                    DataProvider.Insert(SQLInsert, CommandType.Text, parameters.ToArray());
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
