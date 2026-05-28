namespace Statifylib.Data.Models;

public class Artist: SpotifyItem
{
    public List<string> Images { get; set; }
    public int FollowerCount { get; set; }

    
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