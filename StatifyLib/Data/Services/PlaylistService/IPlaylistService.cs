using Statifylib.Data.Models;

namespace Statifylib.Data.Services.PlaylistService;

public interface IPlaylistService
{
    Task<List<Playlist>> GetPlaylists(int userId);
    Task SyncPlaylist(int userID);
    Task SyncTrackToPlaylist(int playlistId);

    Task<List<Track>> GetTracksfomPlaylist(int playlistId,int offset);
}