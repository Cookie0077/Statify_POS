using Statifylib.Data.Models;
using StatifyLib.Data.Models;

namespace Statifylib.Data.Services.UserService;

public class UserServiceFake: IUserService
{
    private List<User> Users = new List<User>()
    {
        new User(){Id = 1, Name = "John Doe"},
        new User(){Id = 2, Name = "Jane Doe"},
        new User(){Id = 3, Name = "Jerry Doe"}
    };

    public Task<List<Artist>> GetTopArtists(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Track>> GetTopTracks(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<User> LoginUser(UserRequest user)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        User oldUser = Users.SingleOrDefault(x => x.Id == user.Id);
        Users.Remove(oldUser);
        Users.Add(user);
    }

  
}