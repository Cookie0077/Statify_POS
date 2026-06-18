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
            userService = new UserService(client);
            artistService = new ArtistService(client);
            trackService = new TrackService(client);
            playlistService = new PlaylistService(client);
        }
    }


    public async Task<List<Artist>> GetArtists()
    {
        List<Artist> artists = await artistService.GetArtists();

        return artists;
    }


    public async Task<List<Artist>> GetTopArtists()
    {
        List<Artist> artists = await artistService.GetTopArtists();

        return artists;
    }


    public async Task SyncUser()
    {
        await trackService.SyncTracks();
        await playlistService.SyncPlaylist();
    }

    public async Task<List<TrackRecord>> GetTracks()
    {
        List<TrackRecord> Tracks = await trackService.GetTracks();
        return Tracks;
    }

    public async Task<List<TrackRecord>> GetTopTracks()
    {
        List<TrackRecord> Tracks = await trackService.GetTopTracks();

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

    public async Task<List<Playlist>> GetPlaylists()
    {
        List<Playlist> playlists = await playlistService.GetPlaylists();

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


    public async Task<List<TrackRecord>> GetTracksFromArtist(int ArtistId, int limit)
    {
        List<TrackRecord> tracks = await artistService.GetTracksfromArtist(ArtistId, limit);
        return tracks;
    }


    public async Task<List<DailyListening>> GetDailyListening()
    {
        List<DailyListening> dailyListenings = await userService.GetDailyListening();
        return dailyListenings;
    }
}
    

