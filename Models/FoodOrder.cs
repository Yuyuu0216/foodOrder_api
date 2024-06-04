using System.ComponentModel.DataAnnotations;
namespace foodOrder_api.Models;

public class Products
{
    public int Id { get; set; }
    public string ?Name { get; set; }
    public string ?Description { get; set; }
    public int Price { get; set; }
}

public class Users{
    public int Id {get;set;}
    public string ?account{get;set;}
    public string ?password{get;set;}
    public string ?phone{get;set;}
}

public class OrderItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CreateOrderRequest
{
    public int UserId { get; set; }
    public int TableNumber { get; set; }
    public List<OrderItem> ?OrderItems { get; set; }
}

public class OrdersData{
    [DataType(DataType.DateTime)]
    public DateTime OrderTime{get;set;}
    public int TotalAmount{get;set;}
    public string ?Status {get;set;}
}