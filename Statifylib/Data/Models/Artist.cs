namespace Statifylib.Data.Models;

public class Artist
{
    public int Id { get; set; }
    public string SpotifyId { get; set; }
    public string Name { get; set; }
    public List<string> Images { get; set; }
    public int FollowerCount { get; set; }
    
    public Artist () {}
}