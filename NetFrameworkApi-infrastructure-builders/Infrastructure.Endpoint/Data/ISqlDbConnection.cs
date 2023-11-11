using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Endpoint.Data
{
    public interface ISqlDbConnection
    {
        //SqlConnection connection { get; set; }
        void OpenConnection();
        void CloseConnection();
        T GetDataRowValue<T>(DataRow row, string index, T defaultValue = default);
        Task<DataTable> ExecuteQueryCommandAsync(SqlCommand sqlCommand);
        Task<int> ExecuteNonQueryCommandAsync(SqlCommand command);
    }
}