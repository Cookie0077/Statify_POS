using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public class Artist: SpotifyItem
{
    public int Playtime { get; set; }
   
    public Artist () {}
    
    public Artist (int id, string name) 
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}