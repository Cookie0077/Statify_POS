#region

using System.Net.Http.Json;
using Statifylib.Data.Models;
using Statifylib.Data.Services.ArtistService;

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
        

        public async Task<List<Artist>> GetArtists(int User_id)
        {
            List<Artist> artists = await client.GetFromJsonAsync<List<Artist>>($"artist/{User_id}");

            return artists;
        }

        public async Task<List<Artist>> GetTopArtists(int User_id)
        {
            List<Artist> artists = await client.GetFromJsonAsync<List<Artist>>($"artist/{User_id}?limit=10");

            return artists;
        }
    }
}