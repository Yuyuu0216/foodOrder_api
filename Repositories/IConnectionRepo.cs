using System.Data.SqlClient;

namespace foodOrder_api.Repositories;

public interface IConnectionRepo
{
    public SqlConnection ConnectDb();
}