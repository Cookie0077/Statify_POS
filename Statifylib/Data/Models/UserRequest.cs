using Statifylib.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace StatifyLib.Data.Models
{
    public class UserRequest: SpotifyItem
    {


        [JsonPropertyName("Password")]
        public string Password { get; set; }  


        public UserRequest(string username,string pw)
        {
           
            Name = username;
            Password = pw;
        }
        
    }
}
