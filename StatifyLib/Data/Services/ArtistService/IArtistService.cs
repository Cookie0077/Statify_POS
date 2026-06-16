<<<<<<< HEAD
﻿using Statifylib.Data.Models;
using StatifyLib.Data.Models;
=======
﻿#region

using Statifylib.Data.Models;

#endregion
>>>>>>> 71d8dfa8b425c191f5ecf37bfc2f1e2b15932239

namespace Statifylib.Data.Services.ArtistService;

public interface IArtistService
{
<<<<<<< HEAD
    Task<Artist> GetArtist(int ArtistId);
    Task<List<Artist>> GetArtists(int UserID);

    Task<List<Artist>> GetTopArtists(int UserID);

    Task<List<TrackRecord>> GetTracksfromArtist(int UserId, int ArtistId, int limit);

=======
    Task<List<Artist>> GetArtists(int User_id);

    Task<List<Artist>> GetTopArtists(int User_id);
>>>>>>> 71d8dfa8b425c191f5ecf37bfc2f1e2b15932239
}