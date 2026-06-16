
using Statifylib.Data.Models;
using StatifyLib.Data.Models;


namespace Statifylib.Data.Services.ArtistService;

public interface IArtistService
{

    Task<Artist> GetArtist(int ArtistId);
    Task<List<Artist>> GetArtists(int UserID);

    Task<List<TrackRecord>> GetTracksfromArtist(int UserId, int ArtistId, int limit);

    Task<List<Artist>> GetTopArtists(int User_id);

}