using System.Data;
using System.Data.SqlClient;
using Dapper;
using foodOrder_api.Models;

namespace foodOrder_api.Repositories;

public class OrderRepo :IOrderRepo
{
    private readonly SqlConnection _connection;

    public OrderRepo(IConnectionRepo connection)
    {
        _connection = connection.ConnectDb();
    }

    public async Task<List<OrdersData>> GetOrderData(int Id) {
        try {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", Id);
            var orders =
                await _connection.QueryAsync<OrdersData>("[dbo].[GetOrdersByUserId]",parameters,
                    commandType: CommandType.StoredProcedure);
                    Console.WriteLine(orders);
            return orders.ToList();
        }
        catch (Exception e) {
            System.Console.WriteLine("error:" + e);
        }

        return null!;
    }

    public async Task<int> CreateOrder(int userId, int tableNum,List<OrderItem> orderItems)
    {
        var orderItemDataTable = new DataTable();
        orderItemDataTable.Columns.Add("ProductId", typeof(int));
        orderItemDataTable.Columns.Add("Quantity", typeof(int));

        foreach (var item in orderItems)
        {
            orderItemDataTable.Rows.Add(item.ProductId, item.Quantity);
        }

        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);
        parameters.Add("@OrderTable", tableNum);
        parameters.Add("@OrderItems", orderItemDataTable.AsTableValuedParameter("OrderItemType"));

        var newOrderId = await _connection.QuerySingleAsync<int>(
            "[dbo].[CreateOrder]",
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return newOrderId;
    }
}