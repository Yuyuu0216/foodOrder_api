using foodOrder_api.Models;

namespace foodOrder_api.Services;

public interface IOrderService
{
    Task<int> CreateOrder(int userId,int tableNum, List<OrderItem> orderItems);
}