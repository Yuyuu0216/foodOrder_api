using foodOrder_api.Models;
namespace foodOrder_api.Repositories;

public interface IAuthRepo
{
    Task<Users> Login(string account);
}