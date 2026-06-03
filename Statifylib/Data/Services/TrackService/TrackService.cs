using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Statifylib.Data.Models;
using StatifyLib.Data.Models;
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
        public async Task<List<TrackRecord>> GetTopTracks(int userId)
        {
            List<TrackRecord> tracks = await client.GetFromJsonAsync<List<TrackRecord>>($"track_record/{userId}?limit=10");
            
            return tracks;
        }

        public async Task SyncTracks(int userId)    
        {
            HttpResponseMessage result = await client.PostAsync($"track_record/sync/{userId}", null);
            result.EnsureSuccessStatusCode();
        }

        public Task<Track> GetTrack(int trackId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TrackRecord>> GetTracks(int userId)
        {
            List<TrackRecord> tracks = await client.GetFromJsonAsync<List<TrackRecord>>($"track_record/{userId}");

            return tracks;
        }

    }
}
