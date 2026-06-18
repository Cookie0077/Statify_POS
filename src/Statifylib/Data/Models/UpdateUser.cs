using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace StatifyLib.Data.Models
{
    public class UpdateUser
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        public UpdateUser(string userName)
        {
            Name = userName;
        }
    }
}
