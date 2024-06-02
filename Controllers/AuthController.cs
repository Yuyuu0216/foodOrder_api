using Microsoft.AspNetCore.Mvc;
using foodOrder_api.Models;
using foodOrder_api.Repositories;
using foodOrder_api.Services;
namespace foodOrder_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthRepo _authRepo;
    private readonly IAuthService _authService;
    public AuthController(IAuthRepo authRepo, IAuthService authService) {
        _authRepo = authRepo;
        _authService = authService;
    }
    [HttpPost]
    public ActionResult<string> Login(Users user)
    {
        return _authService.Login(user);
    }
}