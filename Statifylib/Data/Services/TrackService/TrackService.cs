using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Statifylib.Data.Models;
using Statifylib.Data.Services.TrackService;

namespace StatifyLib.Data.Services.TrackService
{
    public class TrackService : ITrackService
    {
        private HttpClient client;

        public TrackService(HttpClient client)
        {
            this.client = client;
        }
        public Task<List<Track>> GetTopTracks(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Track> GetTrack(int trackId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Track>> GetTracks()
        {
            List<Track> tracks = await client.GetFromJsonAsync<List<Track>>("track");

            return tracks;
        }
    }
}
