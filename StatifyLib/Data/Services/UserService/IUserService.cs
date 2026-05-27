using Statifylib.Data.Models;
using StatifyLib.Data.Models;

namespace Statifylib.Data.Services.UserService;

public interface IUserService
{
    void UpdateUser(User user);
    Task<List<Track>> GetTopTracks(int userId);
    Task<List<Artist>> GetTopArtists(int userId);
    Task<User> LoginUser(UserRequest user);
}