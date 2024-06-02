using foodOrder_api.Models;
using foodOrder_api.Repositories;

namespace foodOrder_api.Services;
public class ProductService : IProductService
{
    private readonly IProductRepo _productRepo;

    public ProductService(IProductRepo productRepo)
    {
        _productRepo = productRepo;
    }

    public List<Products> GetAllProduct()
    {
        var Product = _productRepo.GetAllProduct().Result;
        return Product;
    }
}