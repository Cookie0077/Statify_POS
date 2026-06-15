#region

using Statifylib.Data.Models;

#endregion

namespace Statifylib.Data.Services.ArtistService;

public interface IArtistService
{
    Task<List<Artist>> GetArtists(int User_id);

    Task<List<Artist>> GetTopArtists(int User_id);
}