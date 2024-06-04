using Microsoft.AspNetCore.Mvc;
using foodOrder_api.Models;
using foodOrder_api.Repositories;
using foodOrder_api.Services;
namespace foodOrder_api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly IOrderRepo _orderRepo;
    private readonly IOrderService _orderService;
    public OrderController(IOrderRepo orderRepo, IOrderService orderService) {
        _orderService = orderService;
        _orderRepo = orderRepo;
    }

    [HttpGet("GetOrderData")]
    public Task<List<OrdersData>> GetOrderData(int Id)
    {
        return _orderRepo.GetOrderData(Id);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        try{
        var newOrderId = await _orderService.CreateOrder(request.UserId, request.TableNumber,request.OrderItems);
        return  Ok(new { OrderId = newOrderId });
        }catch (Exception e)
        {
            Console.WriteLine("error:" + e);
            return StatusCode(500, "Internal server error");
        }
    }
}