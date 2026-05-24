using Statifylib.Data.Models;
using Statifylib.Data.Services.ArtistService;
using Statifylib.Data.Services.PlaylistService;
using Statifylib.Data.Services.TrackService;
using Statifylib.Data.Services.UserService;
using System.Net.Http.Headers;

namespace Statifylib.Domain;

public class AppController
{
    private IUserService userService;
    private ITrackService trackService;
    private IPlaylistService playlistService;
    private IArtistService artistService;

    private bool usefakeservice = true;

    public AppController() {

        if (usefakeservice)
        {
            artistService = new ArtistServiceFake();
            trackService = new TrackServiceFake();
        }
    
    }


    public async Task<List<Artist>> GetArtists()
    { 
         List<Artist> artists = await artistService.GetArtists();

        return artists;
    }

    public async Task<List<Track>> GetTracks()
    {
        List<Track> Tracks = await trackService.GetTracks();

        return Tracks;
    }




}
    
 