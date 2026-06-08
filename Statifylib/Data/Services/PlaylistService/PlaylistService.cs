using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Statifylib.Data.Models;
using Statifylib.Data.Services.PlaylistService;

namespace StatifyLib.Data.Services.PlaylistService
{
    public class PlaylistService : IPlaylistService
    {
        private HttpClient client;

        public PlaylistService(HttpClient client)
        {
            this.client = client;
        }

        public void AddPlaylist(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public Task<Playlist> GetPlaylist(int playlistId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Playlist>> GetPlaylists(int userId)
        {
            List<Playlist> playlists = await client.GetFromJsonAsync<List<Playlist>>($"playlist/{userId}");

            return playlists;
        }

        public Task<List<Track>> GetTracks(int playlistId)
        {
            throw new NotImplementedException();
        }
    }
}
