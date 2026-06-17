#region

using System.Net.Http.Json;
using Statifylib.Data.Models;
using StatifyLib.Data.Models;
using Statifylib.Data.Services.UserService;

#endregion

namespace StatifyLib.Data.Services.UserService
{
    public class UserService : IUserService
    {
        private HttpClient client;


        public UserService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<User> LoginUser(UserRequest userRequest)
        {
            HttpResponseMessage result = await client.PostAsJsonAsync("/user/login", userRequest);

            User loggedInUser = await result.Content.ReadFromJsonAsync<User>();


            return loggedInUser;
        }

        public async Task<User> RegisterUser(UserRequest userRequest)
        {
            HttpResponseMessage result = await client.PostAsJsonAsync("/user/register", userRequest);

            User loggedInUser = await result.Content.ReadFromJsonAsync<User>();
            string error = await result.Content.ReadAsStringAsync();

            return loggedInUser;
        }

        public async Task<List<DailyListening>> GetDailyListening(int userId)
        {
            List<DailyListening> result = await client.GetFromJsonAsync<List<DailyListening>>($"track_record/{userId}/playtime");
            return result;
        }
    }
}