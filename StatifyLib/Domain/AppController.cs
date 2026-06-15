#region

using Statifylib.Data.Models;
using StatifyLib.Data.Models;
using Statifylib.Data.Services.ArtistService;
using StatifyLib.Data.Services.ArtistService;
using Statifylib.Data.Services.PlaylistService;
using StatifyLib.Data.Services.PlaylistService;
using Statifylib.Data.Services.TrackService;
using StatifyLib.Data.Services.TrackService;
using Statifylib.Data.Services.UserService;
using StatifyLib.Data.Services.UserService;

#endregion

namespace Statifylib.Domain;

public class AppController
{
    private IUserService userService;
    private ITrackService trackService;
    private IPlaylistService playlistService;
    private IArtistService artistService;

    private bool usefakeservice = false;

    public AppController()
    {
        HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("http://127.0.0.1:8888"),
        };


        if (usefakeservice)
        {
            artistService = new ArtistServiceFake();
            trackService = new TrackServiceFake();
            playlistService = new PlaylistServiceFake();
        }
        else
        {
            client.DefaultRequestHeaders.Add("A-API-Key", "STATIKEY");
            artistService = new ArtistService(client);
            trackService = new TrackService(client);
            userService = new UserService(client);
            playlistService = new PlaylistService(client);
        }
    }


    public async Task<List<Artist>> GetArtists(int userId)
    {
        List<Artist> artists = await artistService.GetArtists(userId);

        return artists;
    }


    public async Task<List<Artist>> GetTopArtists(int userId)
    {
        List<Artist> artists = await artistService.GetTopArtists(userId);

        return artists;
    }


    public async Task SyncUser(int userId)
    {
        await trackService.SyncTracks(userId);
        await playlistService.SyncPlaylist(userId);
    }

    public async Task<List<TrackRecord>> GetTracks(int userId)
    {
        List<TrackRecord> Tracks = await trackService.GetTracks(userId);
        return Tracks;
    }

    public async Task<List<TrackRecord>> GetTopTracks(int userId)
    {
        List<TrackRecord> Tracks = await trackService.GetTopTracks(userId);

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

    public async Task<List<Playlist>> GetPlaylists(int userId)
    {
        List<Playlist> playlists = await playlistService.GetPlaylists(userId);

        return playlists;
    }

    public async Task AddTracksfromPlaylist(int playlistId)
    {
        await playlistService.SyncTrackToPlaylist(playlistId);
    }

    public async Task<List<Track>> GetTracksFromPlaylist(int playlistId, int offset)
    {
        List<Track> tracks = await playlistService.GetTracksfomPlaylist(playlistId, offset);
        return tracks;
    }
}