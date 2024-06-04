using foodOrder_api.Models;
namespace foodOrder_api.Repositories;

public interface IOrderRepo
{
    Task<List<OrdersData>> GetOrderData(int Id);
    Task<int> CreateOrder(int userId, int tableNum,List<OrderItem> orderItems);
}