using Statifylib.Data.Models;

namespace Statifylib.Data.Services.UserService;

public interface IUserService
{
    Task<User> GetUser(int userId);
    void UpdateUser(User user);
    Task<List<Track>> GetTopTracks(int userId);
    Task<List<Artist>> GetTopArtists(int userId);
}