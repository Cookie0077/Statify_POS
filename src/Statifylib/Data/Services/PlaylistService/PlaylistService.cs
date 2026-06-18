#region

using System.Net.Http.Json;
using Statifylib.Data.Models;
using Statifylib.Data.Services.PlaylistService;

#endregion

namespace StatifyLib.Data.Services.PlaylistService
{
    public class PlaylistService : IPlaylistService
    {
        private HttpClient client;

        public PlaylistService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<Playlist>> GetPlaylists()
        {
            List<Playlist> playlists = await client.GetFromJsonAsync<List<Playlist>>($"playlist/");

            return playlists;
        }

        public async Task<List<Track>> GetTracksfomPlaylist(int playlistId, int offset)
        {
            List<Track> playlistTracks =
                await client.GetFromJsonAsync<List<Track>>($"playlist/{playlistId}/tracks?offset={offset}");
            return playlistTracks;
        }

        public async Task SyncPlaylist()
        {
            HttpResponseMessage result = await client.PostAsync($"playlist/sync", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task SyncTrackToPlaylist(int playlistId)
        {
            HttpResponseMessage result = await client.PostAsync($"playlist/sync/{playlistId}/tracks", null);

            result.EnsureSuccessStatusCode();
        }
    }
}