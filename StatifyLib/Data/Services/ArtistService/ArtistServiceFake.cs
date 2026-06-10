using Statifylib.Data.Models;

namespace Statifylib.Data.Services.ArtistService;

public class ArtistServiceFake: IArtistService
{
    private List<Artist> Artists = new List<Artist>()
    {
        new Artist() {Id = 1, Name = "My First Artist", Playtime = 10},
        new Artist() {Id = 2, Name = "My Second Artist", Playtime = 20},
        new Artist() {Id = 3, Name = "My Third Artist", Playtime = 30}
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