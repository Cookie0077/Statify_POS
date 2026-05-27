using Statifylib.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatifyLib.Data.Models
{
    public class UserRequest: SpotifyItem
    {
     
        
        public string Password { get; set; }  


        public UserRequest(string username,string pw)
        {
            Name = username;
            Password = pw;
        }
        
    }
}
