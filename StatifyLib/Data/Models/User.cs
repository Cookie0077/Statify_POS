namespace Statifylib.Data.Models;

public class User: SpotifyItem
{
    public User() { }
    
    public User (string name)
    {
        Name = name;
    }
    public User(string name, int id)
    {
        Name = name;
        Id = id;
    }
}