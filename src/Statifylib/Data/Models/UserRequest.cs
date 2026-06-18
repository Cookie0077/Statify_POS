#region

using System.Text.Json.Serialization;
using Statifylib.Data.Models;

#endregion

namespace StatifyLib.Data.Models
{
    public class UserRequest : SpotifyItem
    {
        [JsonPropertyName("Password")] public string Password { get; set; }


        public UserRequest(string username, string pw)
        {
            Name = username;
            Password = pw;
        }
    }
}