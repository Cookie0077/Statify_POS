#region

using Statifylib.Data.Models;
using StatifyLib.Data.Models;

#endregion

namespace Statifylib.Data.Services.TrackService;

public interface ITrackService
{
    Task<List<TrackRecord>> GetTracks();
    Task<List<TrackRecord>> GetTopTracks();
    Task SyncTracks();
}