using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Microsoft.VisualBasic;
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

        public async Task<List<Playlist>> GetPlaylists(int userId)
        {
            List<Playlist> playlists = await client.GetFromJsonAsync<List<Playlist>>($"playlist/{userId}");

            return playlists;
        }

        public async Task<List<Track>> GetTracksfomPlaylist(int playlistId,int offset)
        {
            List<Track> playlistTracks = await client.GetFromJsonAsync<List<Track>>($"playlist/{playlistId}/tracks?offset={offset}");
            return playlistTracks;
        }

        public async Task SyncPlaylist(int userID)
        {
            HttpResponseMessage result = await client.PostAsync($"playlist/sync/{userID}", null);
            result.EnsureSuccessStatusCode();
        }   

        public async Task SyncTrackToPlaylist(int playlistId)
        {
            HttpResponseMessage result = await client.PostAsync($"playlist/sync/{playlistId}/tracks", null);

            result.EnsureSuccessStatusCode();
        }
    }
}
