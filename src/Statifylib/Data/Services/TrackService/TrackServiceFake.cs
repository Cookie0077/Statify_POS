#region

using Statifylib.Data.Models;
using StatifyLib.Data.Models;

#endregion

namespace Statifylib.Data.Services.TrackService;

public class TrackServiceFake : ITrackService
{
    private List<TrackRecord> trackRecords = new List<TrackRecord>();
    private List<Track> tracks = new List<Track>();

    public TrackServiceFake()
    {
        for (int i = 1; i < 10; i++)
        {
            trackRecords.Add(new TrackRecord()
            {
                Id = i,
                Name = $"Track {i}",
                Artist = $"Artist {i}",
                Duration = 12,
                LastPlayed = DateTime.Today,
                Image = "https://i.scdn.co/image/ab67616d0000b27330a635de2bb0caa4e26f6abb",
                URL = "https://open.spotify.com/track/1hz7SRTGUNAtIQ46qiNv2p",
                PlayCount = i * 9,
            });

            tracks.Add(new Track()
            {
                Id = i,
                Name = $"Track {i}",
            });
        }
    }


    public Task<List<TrackRecord>> GetTracks()
    {
        return Task.FromResult(trackRecords);
    }


    public Task<List<TrackRecord>> GetTopTracks()
    {
        return Task.FromResult(trackRecords);
    }

    public Task SyncTracks()
    {
        return Task.CompletedTask;
    }

   
}