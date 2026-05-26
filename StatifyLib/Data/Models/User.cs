namespace Statifylib.Data.Models;

public class User: SpotifyItem
{
    public string SpotifyId { get; set; }
    public string SpotifyToken { get; set; }
    
    public User () {}
    
    public User (string spotifyId, string spotifyToken)
    {
        SpotifyId = spotifyId;
        SpotifyToken = spotifyToken;
    }
}