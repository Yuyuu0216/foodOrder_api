using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using Dapper;
using foodOrder_api.Models;
using foodOrder_api.Services;

namespace foodOrder_api.Repositories;

public class ProductRepo :IProductRepo
{
    private readonly SqlConnection _connection;

	public ProductRepo(IConnectionRepo connection) {
        _connection = connection.ConnectDb();
    } 

	public async Task<List<Products>> GetAllProduct() {
        try {
            var products =
                await _connection.QueryAsync<Products>("[dbo].[GetAllProducts]",
                    commandType: CommandType.StoredProcedure);
            return products.ToList();
        }
        catch (Exception e) {
            System.Console.WriteLine("error:" + e);
        }

        return null!;
    }
}