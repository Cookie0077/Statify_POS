using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Statifylib.Data.Models;

public class User: SpotifyItem
{
    public User() { }
    public User (string name, int id, string image)
    {
        Name = name;
        Id = id;
        this.Image = image;
    }
   
}