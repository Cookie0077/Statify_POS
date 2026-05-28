using Statifylib.Data.Models;

namespace Statifylib.Data.Services.TrackService;

public class TrackServiceFake: ITrackService
{
    private List<Track> Tracks = new List<Track>()
    {
        new Track() {Id = 1,  Name = "My First Track"},
        new Track() {Id = 2,  Name = "My Second Track"},
        new Track() {Id = 3,  Name = "My Third Track"},
        new Track() {Id = 4,  Name = "My Fourth Track"},
        new Track() {Id = 5,  Name = "My Fifth Track"},
        new Track() {Id = 6,  Name = "My Sixth Track"},
        new Track() {Id = 7,  Name = "My Seventh Track"}
    };
    
    public Task<Track> GetTrack(int trackId)
    {
        return Task.FromResult(Tracks.FirstOrDefault(x => x.Id == trackId));
    }
    

    public Task<List<Track>> GetTracks()
    {
        return  Task.FromResult(Tracks.OrderBy(x => x.Id).ToList());
    }


    public Task<List<Track>> GetTopTracks(int userId)
    {
        return Task.FromResult(Tracks.Where(t => t.Id == userId).ToList());
    }
}