using System.Data.SqlClient;
namespace foodOrder_api.Repositories;

public class ConnectionRepo : IConnectionRepo{
    private readonly SqlConnection _connection;
    
    public ConnectionRepo(IConfiguration config) {
        _connection = new SqlConnection(config.GetConnectionString("ProductContext"));
    }
    
    public SqlConnection ConnectDb() {
        return _connection;
    }
}