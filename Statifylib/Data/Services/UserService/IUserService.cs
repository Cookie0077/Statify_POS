using Statifylib.Data.Models;
using StatifyLib.Data.Models;

namespace Statifylib.Data.Services.UserService;

public interface IUserService
{
    void UpdateUser(User user);
    Task<User> LoginUser(UserRequest user);
}