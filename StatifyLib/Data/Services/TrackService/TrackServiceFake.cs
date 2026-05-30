using Statifylib.Data.Models;

namespace Statifylib.Data.Services.TrackService;

public class TrackServiceFake: ITrackService
{
    private List<Track> Tracks = new List<Track>();

    public TrackServiceFake()
    {
        for (int i = 1;  i < 10; i++)
        {
            Tracks.Add(new Track()
            {
                Id = i,
                Name = $"Track {i}",
                Artist = $"Artist {i}",
                Duration = 12,
                LastPlayed = DateTime.Today,
                PlayCount = i,
                
            });
        }
    }
    
    public Task<Track> GetTrack(int trackId)
    {
        return Task.FromResult(new Track());
    }
    

    public Task<List<Track>> GetTracks()
    {
        return Task.FromResult(Tracks);
    }


    public Task<List<Track>> GetTopTracks(int userId)
    {
        return Task.FromResult(Tracks);
    }

    public Task SyncTracks(int userId)
    {
        return Task.CompletedTask;
    }
}