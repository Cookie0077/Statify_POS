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

    public void AddArtist(Artist artist)
    {
        Artists.Add(artist);
    }

    public Task<List<Artist>> GetArtists(int User_id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Artist>> GetTopArtists(int User_id)
    {
        throw new NotImplementedException();
    }
}