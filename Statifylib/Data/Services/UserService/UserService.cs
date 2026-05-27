using Statifylib.Data.Models;
using Statifylib.Data.Services.UserService;
using StatifyLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace StatifyLib.Data.Services.UserService
{
    public class UserService : IUserService
    {


        private HttpClient client;


       public UserService(HttpClient client)
        {
            this.client = client;
        }
        public Task<List<Artist>> GetTopArtists(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<Artist>> GetTopArtists(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Track>> GetTopTracks(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> LoginUser(UserRequest userRequest)
        {
            HttpResponseMessage result = await client.PostAsJsonAsync("login", userRequest);

            User loggedInUser = await result.Content.ReadFromJsonAsync<User>();

            return loggedInUser;
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
