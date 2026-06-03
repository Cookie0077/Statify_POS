using Statifylib.Data.Models;
using StatifyLib.Data.Models;

namespace Statifylib.Data.Services.TrackService;

public interface ITrackService
{
    Task<Track> GetTrack(int trackId);
    Task<List<TrackRecord>> GetTracks(int UserId);
    Task<List<TrackRecord>> GetTopTracks(int userId);
    Task SyncTracks(int userId);
}