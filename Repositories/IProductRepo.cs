using foodOrder_api.Models;
namespace foodOrder_api.Repositories;

public interface IProductRepo
{
    Task<List<Products>> GetAllProduct();
}