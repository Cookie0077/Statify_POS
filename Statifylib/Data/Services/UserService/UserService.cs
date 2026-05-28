using Statifylib.Data.Models;
using Statifylib.Data.Services.UserService;
using StatifyLib.Data.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
