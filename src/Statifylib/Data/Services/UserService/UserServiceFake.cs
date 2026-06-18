#region

using Statifylib.Data.Models;
using StatifyLib.Data.Models;

#endregion

namespace Statifylib.Data.Services.UserService;

public class UserServiceFake : IUserService
{
    private List<User> Users = new List<User>()
    {
        new User()
        {
            Id = 1, Name = "John Doe", Image = "https://i.scdn.co/image/ab67616d0000b27330a635de2bb0caa4e26f6abb"
        },
        new User() { Id = 2, Name = "Jane Doe" },
        new User() { Id = 3, Name = "Jerry Doe" }
    };


    public Task<User> LoginUser(UserRequest user)
    {
        throw new NotImplementedException();
    }

    public Task<User> RegisterUser(UserRequest userRequest)
    {
        throw new NotImplementedException();
    }

    public Task<List<DailyListening>> GetDailyListening()
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(UpdateUser user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser()
    {
        throw new NotImplementedException();
    }
}