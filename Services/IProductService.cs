using foodOrder_api.Models;

namespace foodOrder_api.Services;

public interface IProductService
{
    List<Products> GetAllProduct();
}