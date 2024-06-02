using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using Dapper;
using foodOrder_api.Models;
using foodOrder_api.Services;

namespace foodOrder_api.Repositories;

public class AuthRepo : IAuthRepo
{
    private readonly SqlConnection _connection;

	public AuthRepo(IConnectionRepo connection) {
        _connection = connection.ConnectDb();
    } 

	public async Task<Users> Login(string account) {
        try {
            Console.WriteLine(account);
            var parameters = new { Account = account };
            var userData =
                await _connection.QueryFirstOrDefaultAsync<Users>("[dbo].[GetUserByAccount]",parameters,
                    commandType: CommandType.StoredProcedure);
            Console.WriteLine(userData);
            return userData;
        }
        catch (Exception e) {
            System.Console.WriteLine("error:" + e);
        }

        return null!;
    }
}