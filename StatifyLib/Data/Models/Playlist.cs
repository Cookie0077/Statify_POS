using System.Text.Json.Serialization;

namespace Statifylib.Data.Models;

public class Playlist: SpotifyItem
{

    public Playlist () {}

    public Playlist(int id, string name, string image)
    {
        this.Id = id;
        this.Image = image;
        this.Name = name;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}