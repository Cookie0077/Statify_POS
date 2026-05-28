using Statifylib.Data.Models;
using Statifylib.Data.Services.ArtistService;
using Statifylib.Data.Services.PlaylistService;
using Statifylib.Data.Services.TrackService;
using Statifylib.Data.Services.UserService;
using StatifyLib.Data.Models;
using StatifyLib.Data.Services.UserService;
using System.Net.Http.Headers;
using StatifyLib.Data.Services.TrackService;

namespace Statifylib.Domain;

public class AppController
{
    private IUserService userService;
    private ITrackService trackService;
    private IPlaylistService playlistService;
    private IArtistService artistService;

    private bool usefakeservice = false;

    public AppController() {
        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://127.0.0.1:8888")
        };

        if (usefakeservice)
        {
            artistService = new ArtistServiceFake();
            trackService = new TrackServiceFake();
            
        }
        else
        {
            artistService = new ArtistServiceFake();
            trackService = new TrackService(client);
            userService = new UserService(client);
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

    public async Task<User> GetUserLogin(UserRequest userRequest)
    {
        User? LoginUser = await userService.LoginUser(userRequest);

        return LoginUser;
    }

    public async Task<User> GetUserRegister(UserRequest userRequest)
    {
        User? RegisteredUser = await userService.RegisterUser(userRequest);

        return RegisteredUser;
    }




}
    
 