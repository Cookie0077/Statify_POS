using Statifylib.Data.Models;
using Statifylib.Domain;
using System.Collections.ObjectModel;
using System.Windows;

namespace Statify;

public class Appview
{
    private AppController appController = new AppController();

    public ObservableCollection<Artist> Topartists {  get; set; }
    public Appview(Window currentwindow)
    {
        currentwindow.DataContext = this;
    }

    public async void InitUI()
    {
        var artists = await appController.GetArtists();

        Topartists = new ObservableCollection<Artist>(artists);
    }

    public void UpdateDashboards()
    {
        throw new NotImplementedException();
    }


}