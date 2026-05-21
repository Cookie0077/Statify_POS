namespace Statifylib.Data.Models;

public class Playlist: SpotifyItem
{
    public int FollowerCount { get; set; }
    public string Owner { get; set; }
    
    public Playlist () {}
}