using Microsoft.AspNetCore.Mvc;
using foodOrder_api.Models;
using foodOrder_api.Repositories;
using foodOrder_api.Services;
namespace foodOrder_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : Controller
{
    private readonly IProductRepo _productRepo;
    private readonly IProductService _productService;
    public ProductsController(IProductRepo productRepo, IProductService productService) {
        _productRepo = productRepo;
        _productService = productService;
    }
    [HttpGet]
    public ActionResult<List<Products>> GetAllProduct()
    {
        return _productService.GetAllProduct();
    }
}