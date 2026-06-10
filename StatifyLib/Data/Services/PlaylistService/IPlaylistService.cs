using Statifylib.Data.Models;

namespace Statifylib.Data.Services.PlaylistService;

public interface IPlaylistService
{
    Task<Playlist> GetPlaylist(int playlistId);
    Task<List<Playlist>> GetPlaylists(int userId);
    void AddPlaylist(Playlist playlist);
    Task<List<Track>> GetTracks(int playlistId);
    Task SyncTrackToPlaylist(int playlistId);
    Task SyncPlaylist(int userID);
}