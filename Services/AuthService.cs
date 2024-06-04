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

    public Users GetUserData(string account)
    {
        return _authRepo.Login(account).Result;
    }

    public string Login(Users user)
    {
        var DBUser = _authRepo.Login(user.account).Result;
        if(DBUser == null){
            return "no user";
        }
        if(DBUser.password == user.password){
            return "login succeed";
        }
        return "login failed";
    }

    public string CreateUser(Users user)
    {
        return _authRepo.CreateUser(user).Result;
    }
}