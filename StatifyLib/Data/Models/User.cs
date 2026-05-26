namespace Statifylib.Data.Models;

public class User: SpotifyItem
{
    public string SpotifyToken { get; set; }
    
    public User () {}
    
    public User ( string spotifyToken)
    {
        SpotifyToken = spotifyToken;
    }
}