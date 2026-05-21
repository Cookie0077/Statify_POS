using Statifylib.Data.Models;

namespace Statifylib.Data.Services.PlaylistService;

public class PlaylistServiceFake: IPlaylistService
{
    private List<Playlist> Playlists = new List<Playlist>()
    {
        new Playlist() {Id = 1,  Name = "My First Playlist"},
        new Playlist() {Id = 2,  Name = "My Second Playlist"},
        new Playlist() {Id = 3,  Name = "My Third Playlist"},
        
    };
    
    public Task<Playlist> GetPlaylist(int playlistId)
    {
        return Task.FromResult(Playlists.Find(x => x.Id == playlistId));
    }

    public Task<List<Playlist>> GetPlaylists()
    {
        return Task.FromResult(Playlists.OrderBy(x => x.Id).ToList());
    }

    public void AddPlaylist(Playlist playlist)
    {
        Playlists.Add(playlist);
    }
}