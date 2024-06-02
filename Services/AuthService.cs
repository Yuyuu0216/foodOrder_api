using foodOrder_api.Models;
using foodOrder_api.Repositories;

namespace foodOrder_api.Services;
public class AuthService : IAuthService
{
    private readonly IAuthRepo _authRepo;

    public AuthService(IAuthRepo authRepo)
    {
        _authRepo = authRepo;
    }

    public string Login(Users user)
    {
        var DBUser = _authRepo.Login(user.account).Result;
        if(DBUser.password == user.password){
            return "login succeed";
        }
        return "login failed";
    }
}