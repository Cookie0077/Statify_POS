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

    private List<Track> Tracks = new List<Track>()
    {
        new Track() { Id = 1, Name = "Track 1" },
        new Track() { Id = 1, Name = "Track 2" },
        new Track() { Id = 2, Name = "Track 3" },
        new Track() { Id = 3, Name = "Track 4" }
    };

    private List<Artist> Artists = new List<Artist>()
    {
        new Artist() { Id = 1, Name = "Artist 1" },
        new Artist() { Id = 2, Name = "Artist 2" }
    };

    public Task<List<Artist>> GetTopArtists(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Track>> GetTopTracks(int userId)
    {
        return Task.FromResult(Tracks.Where(t => t.Id== userId).ToList());
    }

    public Task<User> LoginUser(UserRequest user)
    {
        throw new NotImplementedException();
    }

    public Task<User> RegisterUser(UserRequest userRequest)
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