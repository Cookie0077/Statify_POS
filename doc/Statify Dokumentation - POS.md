#pos 
# Statify Dokumentation - POS
## Team
**Dominik Nageler** & **Jonas Marte**
## Betreuer
**Lukas Diem** & **Christoph Bauer**

```table-of-contents
```

---

<div style="page-break-after: always;"></div>


# 1. Planung (Lastenheft)

![[POS-Projektbeschreibung]]

## GUI-Konzept

### Fensterübersicht

1. Login-Window: Sich mit **Benutzernamen** und **Passwort** anmelden. Ist wichtig für unsere eigene DB und unser Userhandling.
2. Register-Window: Sich mit **Benutzernamen** und **Passwort** registrieren.
3. Main-Window: Hier wird das Handling von unseren **Pages** gemacht. Dafür ist hier ein großer **Frame** hier drauf und oben eine **TabControl**.

### Navigation

Bevor die App voll gestartet ist, öffnet sich im **Browser** ein Fenster wo man sich mit seinem **Spotify Account verknüpfen** muss. Danach kann man sich dann **einloggen** oder **registrieren** bei unserer App.

Nachdem man sich eingeloggt/registriert hat landet man auf der **Main Page**. Hier sieht man - sobald es geladen ist - dann ein paar **wichtige Stats**. Oben links kann man dan per **Mouse-Click** auf die **Tabs** switchen (**Artists, Tracks oder Playlists**). Dann öffnet sich die **korrespondierende Page** mit **genäueren Stats** zu dem **ausgewähltem Punkt**. 

Auf der **Playlistpage** kann man per **Click** auf eine **Playlist** dann die **Songs** von dieser **Playlist holen** - welche dann auch danach angezeigt werden.

<div style="page-break-after: always;"></div>


## UML-Klassendiagramm
### Geplant
```plantuml
@startuml

class AppView {
    - AppController: AppController
    + InitUI(): void
    + UpdateDashboards(): void
}


class AppController {
    - userService: IUserService
    - trackService: ITrackService
    - artistService: IArtistService
    - playlistService: IPlaylistService
    + UpdateStats(): void
    + GetUserStats(): Dict<key, value>
    + GetTrackStats(): Dict<key, value>
    + GetPlaylistStats(): Dict<key, value>
    + GetArtistStats(): Dict<key, value>
}

Package Data{
	class User {
	    + id: int
	    + Name: string
	    + SpotifyId: string
	    + SpotifyToken: string
	}
	
	class Track {
	    + id: int
	    + SpotifyId: string
	    + Name: string
	    + Image: string
	}
	
	class Artist {
	    + id: int
	    + SpotifyId: string
	    + Name: string
	    + Images: List
	    + FollowerCount: int
	}
	
	class Genre {
	    + id: int
	    + Name: string
	}
	
	class Playlist {
	    + id: int
		+ SpotifyId: string
	    + Name: string
	    + FollowerCount: int
	    + Owner: string
	}
	
	
	interface IUserService {
	    + GetUser(): User
	    + UpdateUser(User): void
	    + GetTopTracks(): List<Tracks>
	    + GetTopArtist(): List<Artist>
	    + GetUserStats(User): Dict<key, Value>
	}
	
	interface IArtistService {
	    + GetById(id): Artist
	    + GetTopTracks(id): List<Tracks>
	    + GetArtistStats(Artist): Dict<key, Value>
	}
	
	interface ITrackService {
	    + GetById(id): Track
	    + GetAll(): List<Tracks>
	    + ToggleFavorite(id): void
	    + GetTrackStats(Track): Dict<key, Value>
	}
	
	interface IPlaylistService {
	    + GetAll(): List<Playlist>
	    + GetById(id): Playlist
	    + GetPlaylistStats(Playlist): Dict<key, Value>
	}
	
	' --- Service Implementations ---
	class UserService implements IUserService {
	    + GetUser(): User
	    + UpdateUser(User): void
	    + GetTopTracks(): List<Track>
	    + GetTopArtist(): List<Artist>
	    + GetUserStats(User): Dict<key, Value>
	}
	
	class ArtistService implements IArtistService {
	    + GetById(id): Artist
	    + GetTopTracks(id): List<Track>
	    + GetArtistStats(Artist): Dict<key, Value>
	}
	
	class TrackService implements ITrackService {
	    + GetById(id): Track
	    + GetAll(): List<Track>
	    + GetTrackStats(Track): Dict<key, Value>
	}
	
	class PlaylistService implements IPlaylistService {
	    + GetAll(): List
	    + GetById(id): Playlist
	    + GetPlaylistStats(Playlist): Dict<key, Value>
	}
}


AppView --> AppController : manages
AppController --> IUserService : uses
AppController --> ITrackService : uses
AppController --> IArtistService : uses
AppController --> IPlaylistService : uses

TrackService --> Track: uses
PlaylistService --> Playlist : uses
UserService --> User : uses
ArtistService --> Artist : uses
Genre --> Artist : gets from

@enduml
```

<div style="page-break-after: always;"></div>

### Umsetzung

```plantuml
@startuml

top to bottom direction
skinparam linetype ortho

class AppController {
	- userService : IUserService
	- trackService : ITrackService
	- playlistService : IPlaylistService
	- artistService : IArtistService
	- usefakeservice : bool

	+ AppController()
	+ GetArtists(userId : int) : Task<List<Artist>>
	+ GetTopArtists(userId : int) : Task<List<Artist>>
	+ SyncUser(userId : int) : Task
	+ GetTracks(userId : int) : Task<List<TrackRecord>>
	+ GetTopTracks(userId : int) : Task<List<TrackRecord>>
	+ GetUserLogin(userRequest : UserRequest) : Task<User>
	+ GetUserRegister(userRequest : UserRequest) : Task<User>
	+ GetPlaylists(userId : int) : Task<List<Playlist>>
	+ AddTracksfromPlaylist(playlistId : int) : Task
	+ GetTracksFromPlaylist(playlistId : int, offset : int) : Task<List<Track>>
}



class Artist {
	+ Playtime : int
	+ Artist()
	+ ToString() : string
}

class Playlist {
	+ Playlist()
	+ Playlist(id : int, name : string, image : string)
	+ ToString() : string
}

class Track {
	+ Track()
	+ Track(id : int, name : string, image : string)
	+ ToString() : string
}

class TrackRecord {
	+ LastPlayed : DateTime
	+ Duration : int
	+ UID : int
	+ Name : string
	+ Artist : string
	+ Image : string
	+ PlayCount : int
	+ ToString() : string
}

class User {
	+ User()
	+ User(name : string, id : int, image : string)
}

class UserRequest {
	+ Password : string
	+ UserRequest(username : string, pw : string)
}

abstract class SpotifyItem {
	+ Id : int
	+ Name : string
	+ Image : string
	+ URL : string
}



interface IArtistService {
	+ GetArtists(User_id : int) : Task<List<Artist>>
	+ GetTopArtists(User_id : int) : Task<List<Artist>>
}

class ArtistService {
	- client : HttpClient
	+ ArtistService(client : HttpClient)
	+ GetArtists(User_id : int) : Task<List<Artist>>
	+ GetTopArtists(User_id : int) : Task<List<Artist>>
}


interface IPlaylistService {
	+ AddPlaylist(playlist : Playlist) : void
	+ GetPlaylist(playlistId : int) : Task<Playlist>
	+ GetPlaylists(userId : int) : Task<List<Playlist>>
	+ SyncPlaylist(userID : int) : Task
	+ SyncTrackToPlaylist(playlistId : int) : Task
	+ GetTracksfomPlaylist(playlistId : int, offset : int) : Task<List<Track>>
}

class PlaylistService {
	- client : HttpClient
	+ PlaylistService(client : HttpClient)
	+ AddPlaylist(playlist : Playlist) : void
	+ GetPlaylist(playlistId : int) : Task<Playlist>
	+ GetPlaylists(userId : int) : Task<List<Playlist>>
	+ GetTracksfomPlaylist(playlistId : int, offset : int) : Task<List<Track>>
	+ SyncPlaylist(userID : int) : Task
	+ SyncTrackToPlaylist(playlistId : int) : Task
}


interface ITrackService {
	+ GetTrack(trackId : int) : Task<Track>
	+ GetTracks(UserId : int) : Task<List<TrackRecord>>
	+ GetTopTracks(userId : int) : Task<List<TrackRecord>>
	+ SyncTracks(userId : int) : Task
}

class TrackService {
	- client : HttpClient
	+ TrackService(client : HttpClient)
	+ GetTopTracks(userId : int) : Task<List<TrackRecord>>
	+ SyncTracks(userId : int) : Task
	+ GetTrack(trackId : int) : Task<Track>
	+ GetTracks(userId : int) : Task<List<TrackRecord>>
}


interface IUserService {
	+ UpdateUser(user : User) : void
	+ LoginUser(user : UserRequest) : Task<User>
	+ RegisterUser(userRequest : UserRequest) : Task<User>
}

class UserService {
	- client : HttpClient
	+ UserService(client : HttpClient)
	+ LoginUser(userRequest : UserRequest) : Task<User>
	+ RegisterUser(userRequest : UserRequest) : Task<User>
	+ UpdateUser(user : User) : void
}

IArtistService <|.. ArtistService
IPlaylistService <|.. PlaylistService
ITrackService <|.. TrackService
IUserService <|.. UserService


AppController --> IUserService : uses
AppController --> ITrackService : uses
AppController --> IArtistService : uses
AppController --> IPlaylistService : uses

ArtistService --> Artist: returns
PlaylistService --> Playlist: returns
PlaylistService --> Track: returns
TrackService --> Track: returns
TrackService --> TrackRecord: returns
UserService --> User: returns
UserService --> UserRequest: returns

Artist -[hidden]down-> SpotifyItem
Playlist -[hidden]down-> SpotifyItem
Track -[hidden]down-> SpotifyItem
TrackRecord -[hidden]down-> SpotifyItem
User -[hidden]down-> SpotifyItem
UserRequest -[hidden]down-> SpotifyItem

Artist --|> SpotifyItem
Playlist --|> SpotifyItem
Track --|> SpotifyItem
TrackRecord --|> SpotifyItem
User --|> SpotifyItem
UserRequest --|> SpotifyItem

@enduml
```


---

<div style="page-break-after: always;"></div>

# 2. Umsetzung

## Verwendete Technologien

| Technologie / Paket              | Version         |
| -------------------------------- | --------------- |
| .NET                             | 10.0            |
| WPF                              | net10.0-windows |
| coverlet.collector               | 6.0.4           |
| Microsoft.NET.Test.Sdk           | 17.14.1         |
| xunit.runner.visualstudio        | 3.1.4           |
| LiveChartsCore.SkiaSharpView.WPF | 2.0.4           |
| Serilog                          | 4.3.1           |
| Serilog.Sinks.Console            | 6.1.1           |
| Serilog.Sinks.File               | 7.0.0           |
| Uno.UI                           | 5.6.99          |
| xunit                            | 2.9.3           |
## Projektstruktur

Der **AppController** managed unsere ganze App so ziemlich. Er ruft dann immer in den **jeweiligen Services** die **Methode** auf die gebraucht wird um das gewollte zu **GET, POST, PUT oder DELETE**. Dafür hat **jede Page** immer einen **AppController** über den sie dann die Funktionen aufrufen kann.

Zwischen den Pages kann man wechseln indem man über unsere **TabControl** auf dem **MainWindow** wechselt, welche **Page** in unserem **MainFrame** angezeigt wird.

---
# 3. Vergleich Planung vs Umsetzung

| Geplant      | Ergebnis        | Bemerkung                                                                                |
| ------------ | --------------- | ---------------------------------------------------------------------------------------- |
| Stats Filter | Nicht gemacht   | Zeitmangel & wenig Nutzen                                                                |
| Genre        | Nicht vorhanden | Spotify API unterstütz es nicht mehr                                                     |
| AppView      | Nicht vorhanden | Jede Page hat einen AppController und managed sich selbst od Mainwindow managed den Rest |

---
# 4. KI-Unterstützung

## Verwendete Tools

- ChatGPT
- GitHub Copilot
- Claude Code
- Claude

## Beispiele

### Prompt

```text
How can i fix the playtime in my artists diagram?
```

### Ergebnis

Als Ergebnis habe ich dann die **MsToMinutesConverter** Klasse gekriegt. Diese konnte ich danach dann immer bei **Bindings** leicht reinschreiben.

---

# 5. Projekttagebuch

| Datum      | Person  | Tätigkeit                                                             |
| ---------- | ------- | --------------------------------------------------------------------- |
| 21.05.2026 | Dominik | Repository, AppController/AppView, erste Fake Services                |
| 21.05.2026 | Jonas   | Projektinitialisierung, Basisklassen, Fake Services                   |
| 22.05.2026 | Jonas   | Projektstruktur angepasst, Library umgestellt                         |
| 24.05.2026 | Dominik | Track FakeService implementiert                                       |
| 25.05.2026 | Dominik | Dashboard-Paket, TabHandling, Pages                                   |
| 26.05.2026 | Jonas   | Fake Services, Artist Page, PieChart                                  |
| 27.05.2026 | Dominik | Login/Register-Fenster, User-Login                                    |
| 27.05.2026 | Jonas   | SpotifyItem-Modell bereinigt                                          |
| 28.05.2026 | Dominik | User Login/Register, TrackService                                     |
| 28.05.2026 | Jonas   | TrackPage, UserService, Track Model Refactoring                       |
| 30.05.2026 | Jonas   | Track-Sync, TrackRecord, UI-/Model-Anpassungen                        |
| 31.05.2026 | Dominik | ArtistService, Bilderanzeige                                          |
| 31.05.2026 | Jonas   | Playlist Page, Playlist-Fake-Daten                                    |
| 01.06.2026 | Dominik | SpotifyItemView, SpotifyViewModel                                     |
| 01.06.2026 | Jonas   | TrackPage, Chart-Anpassungen, TODOs bereinigt                         |
| 02.06.2026 | Dominik | TrackDetailPage                                                       |
| 02.06.2026 | Jonas   | TrackPage GridView, Quality-of-Life-Anpassungen                       |
| 03.06.2026 | Dominik | Authorization, UI-Anpassungen, Fullscreen                             |
| 03.06.2026 | Jonas   | TrackPage aktualisiert                                                |
| 08.06.2026 | Dominik | PlaylistService                                                       |
| 08.06.2026 | Jonas   | Zwischenstand                                                         |
| 10.06.2026 | Dominik | ArtistDetailPage, PlaylistView, Artist/PlaylistService                |
| 10.06.2026 | Jonas   | Playtime Artist, FakeServices-Fixes                                   |
| 11.06.2026 | Dominik | Spotify-Button, URL, Artist FakeService                               |
| 11.06.2026 | Jonas   | AI-Design-Refactoring, PlaylistPage, TrackPage PieChart               |
| 13.06.2026 | Dominik | PlaylistDetailPage, SpotifyItemView UI, API-Call-Optimierung          |
| 13.06.2026 | Jonas   | Loading Screen, Login/Register Redesign, Duration Converter, Bugfixes |
| 14.06.2026 | Jonas   | TrackPage-Bilder, Scroll-Funktion, BarChart, TODOs entfernt           |
| 15.06.2026 | Dominik | Letzte Änderungen, Merge, Zwischenstand                               |

<div style="page-break-after: always;"></div>

# 6. Reflexion

## Was lief gut?
- Arbeitsmoral
- Zeitplan
- Spotify-Account Verknüpfen
- Ohne AI Teil ging viel besser wie erwartet

## Was lief schlecht?
- 24h Ban bei zu vielen Requests
- DB-Planung

## Wo war KI hilfreich?
- UI Design
- Fehler finden
- Livecharts Nugget Package lernen

## Was würden wir anders machen?
- Aufgabenverteilung bei der Planung mit mehr Mühe und bedacht machen
- Mehr Funktionalität 
	- Adden
	- Spotify Player kleiner

---

# 7. Quellen

## Bilder / Medien

| Quelle                                          | Lizenz                                                     |
| ----------------------------------------------- | ---------------------------------------------------------- |
| https://www.flaticon.com/free-icon/user_1144760 | Free for personal and commercial purpose with attribution. |

---

# 8. Repository

GitHub-Link: https://github.com/Cookie0077/Statify_POS