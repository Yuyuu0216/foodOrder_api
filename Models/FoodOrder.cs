namespace foodOrder_api.Models;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}

public class Users{
    public int Id {get;set;}
    public string account{get;set;}
    public string password{get;set;}
    public string phone{get;set;}
}