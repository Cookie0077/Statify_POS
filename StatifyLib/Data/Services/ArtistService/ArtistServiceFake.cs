

using Statifylib.Data.Models;
using StatifyLib.Data.Models;

namespace Statifylib.Data.Services.ArtistService;

public class ArtistServiceFake : IArtistService
{

        private List<TrackRecord> trackRecords = new List<TrackRecord>();

    private List<Artist> Artists = new List<Artist>()
    {
        new Artist()
        {
            Id = 1, Name = "My First Artist", Playtime = 10,
            Image = "https://i.scdn.co/image/ab6761610000e5eb6e835a500e791bf9c27a422a",
            URL = "https://open.spotify.com/artist/5K4W6rqBFWDnAN6FQUkS6x"
        },
        new Artist()
        {
            Id = 2, Name = "My Second Artist", Playtime = 20,
            Image = "https://i.scdn.co/image/ab6761610000e5eb6e835a500e791bf9c27a422a",
            URL = "https://open.spotify.com/artist/5K4W6rqBFWDnAN6FQUkS6x"
        },
        new Artist()
        {
            Id = 3, Name = "My Third Artist", Playtime = 30,
            Image = "https://i.scdn.co/image/ab6761610000e5eb6e835a500e791bf9c27a422a",
            URL = "https://open.spotify.com/artist/5K4W6rqBFWDnAN6FQUkS6x"
        }
    };
    
        public ArtistServiceFake()
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
            }
        }


        public Task<Artist> GetArtist(int artistId)
        {
            return Task.FromResult(Artists.Find(x => x.Id == artistId));
        }

        public void AddArtist(Artist artist)
        {
            Artists.Add(artist);
        }

        public Task<List<Artist>> GetArtists(int User_id)
        {
            return Task.FromResult(Artists);
        }

        public Task<List<Artist>> GetTopArtists(int User_id)
        {
            return Task.FromResult(Artists);
        }

        public Task<List<TrackRecord>> GetTracksfromArtist(int UserId, int ArtistId, int limit)
        {
        return Task.FromResult(trackRecords);
    }
}