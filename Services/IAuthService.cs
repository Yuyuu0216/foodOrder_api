using foodOrder_api.Models;

namespace foodOrder_api.Services;

public interface IAuthService
{
    string Login(Users user);
    string CreateUser(Users user);
}