namespace Statifylib.Data.Models;

public abstract class SpotifyItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SpotifyId { get; set; }
}