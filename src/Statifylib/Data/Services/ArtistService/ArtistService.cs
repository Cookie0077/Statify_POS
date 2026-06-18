#region

using System.Net.Http.Json;
using Statifylib.Data.Models;
using Statifylib.Data.Services.ArtistService;
using StatifyLib.Data.Models;

#endregion

namespace StatifyLib.Data.Services.ArtistService
{
    public class ArtistService : IArtistService
    {
        private HttpClient client;

        public ArtistService(HttpClient client)
        {
            this.client = client;
        }

        public Task<Artist> GetArtist(int ArtistId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Artist>> GetArtists()
        {
            List<Artist> artists = await client.GetFromJsonAsync<List<Artist>>($"artist/");

            return artists;
        }

        public async Task<List<Artist>> GetTopArtists()
        {
            List<Artist> artists = await client.GetFromJsonAsync<List<Artist>>($"artist/?limit=10");

            return artists;
        }

        public async Task<List<TrackRecord>> GetTracksfromArtist( int ArtistId, int limit)
        {
            List<TrackRecord> tracks = await client.GetFromJsonAsync<List<TrackRecord>>($"artist/{ArtistId}/tracks?limit={limit}");

            return tracks;
        }
    }
}