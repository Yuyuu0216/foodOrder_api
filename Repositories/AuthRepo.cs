using System.Data;
using System.Data.SqlClient;
using Dapper;
using foodOrder_api.Models;

namespace foodOrder_api.Repositories;

public class AuthRepo : IAuthRepo
{
    private readonly SqlConnection _connection;

	public AuthRepo(IConnectionRepo connection) {
        _connection = connection.ConnectDb();
    } 

	public async Task<Users> Login(string account) {
        try {
            var parameters = new { Account = account };
            var userData =
                await _connection.QueryFirstOrDefaultAsync<Users>("[dbo].[GetUserByAccount]",parameters,
                    commandType: CommandType.StoredProcedure);
            return userData;
        }
        catch (Exception e) {
            System.Console.WriteLine("error:" + e);
        }

        return null!;
    }

    public async Task<string> CreateUser(Users user) {
        try {
            var parameters = new { Account = user.account, Password = user.password, Phone = user.phone };
            var userName =
                await _connection.QueryFirstOrDefaultAsync<string>("[dbo].[CreateUser]",parameters,
                    commandType: CommandType.StoredProcedure);
            return userName;
        }
        catch (Exception e) {
            Console.WriteLine("error:" + e);
        }

        return null!;
    }
}