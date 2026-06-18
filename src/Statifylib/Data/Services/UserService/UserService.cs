#region

using Statifylib.Data.Models;
using Statifylib.Data.Services.UserService;
using StatifyLib.Data.Models;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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
            await GetToken(userRequest);


            return loggedInUser;
        }

        public async Task<User> RegisterUser(UserRequest userRequest)
        {
            HttpResponseMessage result = await client.PostAsJsonAsync("/user/register", userRequest);

            User loggedInUser = await result.Content.ReadFromJsonAsync<User>();

            await GetToken(userRequest);

            return loggedInUser;
        }

        private async Task GetToken(UserRequest user)
        {

            KeyValuePair<string, string>[] data = new[]

            {

                new KeyValuePair<string, string>("grant_type", "password"),

                new KeyValuePair<string, string>("username", user.Name),

                new KeyValuePair<string, string>("password", user.Password)

            };
            var content = new FormUrlEncodedContent(data);
            var result = await client.PostAsync("token/", content);
            if (result.IsSuccessStatusCode)
            {
                Token token = await result.Content.ReadFromJsonAsync<Token>();
                Debug.WriteLine(token.access_token);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(token.token_type, token.access_token);
            }
            else
            {
                var error = await result.Content.ReadAsStringAsync();
                Debug.WriteLine($"Token request failed: {result.StatusCode} - {error}");
            }
        }

        public async Task<List<DailyListening>> GetDailyListening()
        {
            List<DailyListening> result = await client.GetFromJsonAsync<List<DailyListening>>($"track_record/playtime");
            return result;
        }
    }
}