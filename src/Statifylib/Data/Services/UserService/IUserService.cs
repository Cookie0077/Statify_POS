#region

using Statifylib.Data.Models;
using StatifyLib.Data.Models;

#endregion

namespace Statifylib.Data.Services.UserService;

public interface IUserService
{
    Task<User> LoginUser(UserRequest user);
    Task<User> RegisterUser(UserRequest userRequest);
    Task<List<DailyListening>> GetDailyListening();
}