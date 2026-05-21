namespace Statifylib.Data.Models;

public class Playlist
{
    public int Id { get; set; }
    public string SpotifyId { get; set; }
    public string Name { get; set; }
    public int FollowerCount { get; set; }
    public string Owner { get; set; }
    
    public Playlist () {}
}