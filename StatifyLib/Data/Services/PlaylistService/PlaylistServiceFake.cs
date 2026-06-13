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

    private List<Track> Tracks = new List<Track>()
    {
        new Track() { Id = 1, Name = "Track 1" },
        new Track() { Id = 1, Name = "Track 2" },
        new Track() { Id = 2, Name = "Track 3" },
        new Track() { Id = 2, Name = "Track 4" },
        new Track() { Id = 1, Name = "Track 5" }
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


    public Task<List<Playlist>> GetPlaylists(int userId)
    {
        return Task.FromResult(Playlists);
    }

    public Task SyncPlaylist(int UserID)
    {
        return Task.CompletedTask;
    }

    public Task SyncTrackToPlaylist(int playlistId)
    {
        return Task.CompletedTask;
    }

    public Task<List<Track>> GetTracksfomPlaylist(int playlistId,int offset)
    {
        return Task.FromResult(Tracks.Where(t => t.Id == playlistId).ToList());
    }
}