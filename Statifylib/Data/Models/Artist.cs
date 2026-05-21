namespace Statifylib.Data.Models;

public class Artist: SpotifyItem
{
    public List<string> Images { get; set; }
    public int FollowerCount { get; set; }
    
    public Artist () {}
    
    public Artist (int id, string spotifyId, string name) 
    {
        Id = id;
        SpotifyId = spotifyId;
        Name = name;
    }
}