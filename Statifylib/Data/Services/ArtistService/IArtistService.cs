using Statifylib.Data.Models;

namespace Statifylib.Data.Services.ArtistService;

public interface IArtistService
{
    Task<Artist> GetArtist(int artistId);
    Task<List<Artist>> GetArtists();
    void AddArtist(Artist artist);
}