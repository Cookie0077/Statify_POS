#region

using Statifylib.Data.Models;
using StatifyLib.Data.Models;

#endregion

namespace Statifylib.Data.Services.TrackService;

public interface ITrackService
{
    Task<List<TrackRecord>> GetTracks(int UserId);
    Task<List<TrackRecord>> GetTopTracks(int userId);
    Task SyncTracks(int userId);
}