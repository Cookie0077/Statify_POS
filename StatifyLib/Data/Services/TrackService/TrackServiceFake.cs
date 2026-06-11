using Statifylib.Data.Models;
using StatifyLib.Data.Models;
using static System.Net.WebRequestMethods;

namespace Statifylib.Data.Services.TrackService;

public class TrackServiceFake: ITrackService
{
    private List<TrackRecord> trackRecords = new List<TrackRecord>();
    private List<Track> tracks = new List<Track>();

    public TrackServiceFake()
    {
        for (int i = 1;  i < 10; i++)
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
                PlayCount =  i * 9,
                
            });

            tracks.Add(new Track()
            {
                Id = i,
                Name = $"Track {i}",
            });
        }
    }
    
    public Task<Track> GetTrack(int trackId)
    {
        return Task.FromResult(tracks.Find(x => x.Id == trackId));
    }
    

    public Task<List<Track>> GetTracks()
    {
        return Task.FromResult(tracks);
    }


    public Task<List<TrackRecord>> GetTopTracks(int userId)
    {
        return Task.FromResult(trackRecords);
    }

    public Task SyncTracks(int userId)
    {
        return Task.CompletedTask;
    }

    public Task<List<TrackRecord>> GetTracks(int UserId)
    {
        return Task.FromResult(trackRecords);
    }
}