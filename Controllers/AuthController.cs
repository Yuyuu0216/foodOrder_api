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

    [HttpGet("userData")]
    public ActionResult<Users> GetUserData(string account)
    {
        return _authService.GetUserData(account);
    }

    [HttpPost("isLogin")]
    public ActionResult<string> Login(Users user)
    {
        return _authService.Login(user);
    }

    [HttpPost("Register")]
    public ActionResult<string> CreateUser(Users user)
    {
        return _authService.CreateUser(user);
    }
}