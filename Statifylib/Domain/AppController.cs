using Statifylib.Data.Services.ArtistService;
using Statifylib.Data.Services.PlaylistService;
using Statifylib.Data.Services.TrackService;
using Statifylib.Data.Services.UserService;

namespace Statifylib.Domain;

public class AppController
{
    private IUserService userService;
    private ITrackService trackService;
    private IPlaylistService playlistService;
    private IArtistService artistService;
    
    public AppController(IUserService uS,  ITrackService tS, IPlaylistService pS, IArtistService aS)
    {
        userService = uS;
        trackService = tS;
        playlistService = pS;
        artistService = aS;
    }
}