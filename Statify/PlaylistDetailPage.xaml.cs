using Statifylib.Data.Models;
using Statifylib.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Track = Statifylib.Data.Models.Track;

namespace Statify
{
    /// <summary>
    /// Interaction logic for PlaylistDetailPage.xaml
    /// </summary>
    public partial class PlaylistDetailPage : Page
    {
        private AppController appController = new AppController();
        private Playlist playlist;

        private bool _initialized= false;

        private int offset;

        
        public PlaylistDetailPage(Playlist playlist)
        {
            InitializeComponent();
            this.playlist = playlist;
            TextBlockPlaylistName.Text = playlist.Name;
            
            Loaded += Page_Loaded;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_initialized) return;
            _initialized = true;

            Loaded -= Page_Loaded;
            InitUI();
        }



        public async void InitUI()
        {
            // redundanter call 
            await appController.AddTracksfromPlaylist(playlist.Id);
            List<Track> tracks = await appController.GetTracksFromPlaylist(playlist.Id,offset);
            if (tracks.Count <= 0 && offset >0)
            {
                offset -= 50;
                InitUI();
            }
            else
            {
                TrackView.GetSpotifyItemList(tracks.Cast<SpotifyItem>().ToList(), this.NavigationService);
            }
            
            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
        }

        private void ButtonViewOnSpotify_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = playlist.URL,
                UseShellExecute = true
            });
        }

        private void ButtonNext_OnClick(object sender, RoutedEventArgs e)
        {
          
            offset += 50;
            TrackView.Clear();
            InitUI();
        }

        private void ButtonBack_OnClick(object sender, RoutedEventArgs e)
        {
            offset -= 50;
            if (offset < 0)
            {
                offset = 0;
            }
            TrackView.Clear();
            InitUI();
        }
    }
}
