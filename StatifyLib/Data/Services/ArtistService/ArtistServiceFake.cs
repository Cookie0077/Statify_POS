using Statifylib.Data.Models;

namespace Statifylib.Data.Services.ArtistService;

public class ArtistServiceFake: IArtistService
{
    private List<Artist> Artists = new List<Artist>()
    {
        new Artist(1,  "My First Artist"),
        new Artist(2,  "My Second Artist"),
        new Artist(3, "My Third Artist")
    };
    
    public Task<Artist> GetArtist(int artistId)
    {
        return Task.FromResult(Artists.Find(x => x.Id == artistId));
    }

    public Task<List<Artist>> GetArtists()
    {
        return Task.FromResult(Artists.OrderBy(x => x.Id).ToList());
    }

    public void AddArtist(Artist artist)
    {
        Artists.Add(artist);
    }
}