using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data
{
    public class SqlDbConnection : ISqlDbConnection
    {
        private static SqlDbConnection _instance;
        //public SqlConnection connection { get; set; }
        public readonly SqlConnection connection;

        private SqlDbConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSQLServer"].ConnectionString;
            connection = new SqlConnection(connectionString);

            OpenConnection();
        }

        public static SqlDbConnection GetInstance()
        {
            if (_instance is null)
            {
                _instance = new SqlDbConnection();
            }

            return _instance;
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Open) return;

            connection.Open();
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Closed) return;

            connection.Close();
        }

        public async Task<DataTable> ExecuteQueryCommandAsync(SqlCommand command)
        {
            OpenConnection();
            DataTable dt = new DataTable();
            command.Connection = connection;
            SqlDataReader reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            command.Dispose();
            return dt;
        }

        public async Task<int> ExecuteNonQueryCommandAsync(SqlCommand command)
        {
            OpenConnection();
            command.Connection = connection;
            int affectedRows = await command.ExecuteNonQueryAsync();
            command.Dispose();
            return affectedRows;
        }

        public SqlDataAdapter CreateDataApdapter(string query)
        {
            return new SqlDataAdapter(query, connection);
        }

        public T GetDataRowValue<T>(DataRow row, string index, T defaultValue = default)
        {
            return !row.IsNull(index) ? (T)row[index] : defaultValue;
        }
    }
}
