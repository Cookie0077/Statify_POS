#region

using Statifylib.Data.Models;
using Statifylib.Data.Services.TrackService;
using StatifyLib.Data.Models;
using System.Diagnostics;
using System.Net.Http.Json;

#endregion

namespace StatifyLib.Data.Services.TrackService
{
    public class TrackService : ITrackService
    {
        private HttpClient client;

        public TrackService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<TrackRecord>> GetTopTracks()
        {
            List<TrackRecord> tracks = await client.GetFromJsonAsync<List<TrackRecord>>($"track_record/?limit=10");

            return tracks;
        }

        public async Task SyncTracks()
        {
            HttpResponseMessage result = await client.PostAsync($"track_record/sync", null);
            if (!result.IsSuccessStatusCode)
            {
                var error = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Sync failed: {result.StatusCode} - {error}");
            }
            result.EnsureSuccessStatusCode();
        }

        public async Task<List<TrackRecord>> GetTracks()
        {
            List<TrackRecord> tracks = await client.GetFromJsonAsync<List<TrackRecord>>($"track_record/");

            return tracks;
        }
    }
}