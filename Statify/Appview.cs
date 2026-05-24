using Statifylib.Data.Models;
using Statifylib.Domain;
using System.Collections.ObjectModel;
using System.Windows;

namespace Statify;

public class Appview
{
    private AppController appController = new AppController();

    public ObservableCollection<Artist> Topartists {  get; private set; }
    public ObservableCollection<Track> TopTracks { get; private set; }
    public Appview(Window currentwindow)
    {
        currentwindow.DataContext = this;
    }

    public async void InitUI()
    {
        List<Artist> artists = await appController.GetArtists();
        List<Track> tracks = await appController.GetTracks();

        TopTracks = new ObservableCollection<Track>(tracks);
        Topartists = new ObservableCollection<Artist>(artists);
    }

    public void UpdateDashboards()
    {
        throw new NotImplementedException();
    }


}