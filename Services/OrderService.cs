using foodOrder_api.Models;
using foodOrder_api.Repositories;

namespace foodOrder_api.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepo _orderRepo;

    public OrderService(IOrderRepo orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<int> CreateOrder(int userId, int tableNum,List<OrderItem> orderItems)
    {
        return await _orderRepo.CreateOrder(userId,tableNum, orderItems);
    }
}