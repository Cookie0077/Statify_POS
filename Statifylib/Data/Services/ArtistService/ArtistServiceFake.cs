using Statifylib.Data.Models;

namespace Statifylib.Data.Services.ArtistService;

public class ArtistServiceFake: IArtistService
{
    private List<Artist> Artists = new List<Artist>()
    {
        new Artist(1, "ID1", "Test1"),
        new Artist(2, "ID2", "Test2"),
        new Artist(3, "ID3", "Test3")
    };
    
    public Task<Artist> GetArtist(int artistId)
    {
        //return Task.FromResult(Artists.OrderBy(x => x.id).ToList());
        throw new NotImplementedException();
    }

    public Task<List<Artist>> GetArtists()
    {
        throw new NotImplementedException();
    }

    public void AddArtist(Artist artist)
    {
        throw new NotImplementedException();
    }
}