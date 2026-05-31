using Statifylib.Data.Models;

namespace Statifylib.Data.Services.ArtistService;

public interface IArtistService
{
    Task<Artist> GetArtist(int artistId);
    Task<List<Artist>> GetArtists(int User_id);

    Task<List<Artist>> GetTopArtists(int User_id);



}