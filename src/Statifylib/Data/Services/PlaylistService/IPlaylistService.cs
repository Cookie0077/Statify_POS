#region

using Statifylib.Data.Models;

#endregion

namespace Statifylib.Data.Services.PlaylistService;

public interface IPlaylistService
{
    Task<List<Playlist>> GetPlaylists();
    Task SyncPlaylist();
    Task SyncTrackToPlaylist(int playlistId);
    Task<List<Track>> GetTracksfomPlaylist(int playlistId, int offset);
}