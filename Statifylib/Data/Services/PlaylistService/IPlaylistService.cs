using Statifylib.Data.Models;

namespace Statifylib.Data.Services.PlaylistService;

public interface IPlaylistService
{
    Task<Playlist> GetPlaylist(int playlistId);
    Task<List<Playlist>> GetPlaylists();
    void AddPlaylist(Playlist playlist);
}