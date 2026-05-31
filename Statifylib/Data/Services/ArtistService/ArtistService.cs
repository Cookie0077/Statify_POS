using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Statifylib.Data.Models;
using Statifylib.Data.Services.ArtistService;

namespace StatifyLib.Data.Services.ArtistService
{
    public class ArtistService : IArtistService
    {

        private HttpClient client;

        public ArtistService(HttpClient client)
        {
            this.client = client;
        }
        public Task<Artist> GetArtist(int artistId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> GetArtists(int User_id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Artist>> GetTopArtists(int User_id)
        {
            List<Artist> artists = await client.GetFromJsonAsync<List<Artist>>($"artist/{User_id}?limit=10");

            return artists;
        }
    }
}
