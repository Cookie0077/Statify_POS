using Statifylib.Data.Models;

namespace Statifylib.Data.Services.TrackService;

public interface ITrackService
{
    Task<Track> GetTrack(int trackId);
    Task<List<Track>> GetTracks();
    void AddTrack(Track track);
}