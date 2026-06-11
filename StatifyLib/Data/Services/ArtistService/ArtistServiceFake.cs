using Statifylib.Data.Models;
using static System.Net.WebRequestMethods;

namespace Statifylib.Data.Services.ArtistService;

public class ArtistServiceFake: IArtistService
{
    private List<Artist> Artists = new List<Artist>()
    {
        new Artist() { Id = 1, Name = "My First Artist", Playtime = 10, Image = "https://i.scdn.co/image/ab6761610000e5eb6e835a500e791bf9c27a422a", URL = "https://open.spotify.com/artist/5K4W6rqBFWDnAN6FQUkS6x" },
        new Artist() { Id = 2, Name = "My Second Artist", Playtime = 20, Image = "https://i.scdn.co/image/ab6761610000e5eb6e835a500e791bf9c27a422a", URL = "https://open.spotify.com/artist/5K4W6rqBFWDnAN6FQUkS6x" },
        new Artist() { Id = 3, Name = "My Third Artist", Playtime = 30, Image = "https://i.scdn.co/image/ab6761610000e5eb6e835a500e791bf9c27a422a", URL = "https://open.spotify.com/artist/5K4W6rqBFWDnAN6FQUkS6x" }
    };
    public Task<Artist> GetArtist(int artistId)
    {
        return Task.FromResult(Artists.Find(x => x.Id == artistId));
    }

    public void AddArtist(Artist artist)
    {
        Artists.Add(artist);
    }

    public Task<List<Artist>> GetArtists(int User_id)
    {
        return Task.FromResult(Artists);
    }

    public Task<List<Artist>> GetTopArtists(int User_id)
    {
        return Task.FromResult(Artists);
    }
}