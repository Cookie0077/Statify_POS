using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Statifylib.Data.Models;
using Statifylib.Domain;

namespace Statify
{
    /// <summary>
    /// Interaction logic for PlaylistDetailPage.xaml
    /// </summary>
    public partial class PlaylistDetailPage : Page
    {
        private AppController appController = new AppController();
        private Playlist playlist;
        public PlaylistDetailPage(Playlist playlist)
        {
            InitializeComponent();
            this.playlist = playlist;
            
            Loaded += (sender, args) => InitUI();
        }
        
        public async void InitUI()
        {
            appController.AddTracksfromPlaylist(playlist.Id);
            List<Track> tracks = await appController.GetTracksByPlaylist(playlist.Id);
            TrackView.GetSpotifyItemList(tracks.Cast<SpotifyItem>().ToList(),this.NavigationService);
        }
    }
}
