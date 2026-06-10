using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public class Track: SpotifyItem
{
    
    public Track () {}

    public Track(int id, string name,string image)
    {
        Id = id;
        Name = name;
        this.Image = image;
    }


    public override string ToString()
    {
        return $"{Name}";
    }
}