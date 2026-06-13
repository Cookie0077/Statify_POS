using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Statifylib.Data.Services.PlaylistService;
using Statifylib.Domain;

namespace Statify
{
    /// <summary>
    /// Interaction logic for PlaylistPage.xaml
    /// </summary>
    public partial class PlaylistPage : Page
    {
        private int UserId;
        private AppController appController = new AppController();

        public ObservableCollection<Playlist> TopPlaylists { get; set; } = new ObservableCollection<Playlist>();
        public ObservableCollection<Track> Tracks { get; set; } = new ObservableCollection<Track>();

        private bool _initialized = false;


        public PlaylistPage(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
            DataContext = this;
            // TODO: Add Loading Screen as the Playlist Sync takes longer than the GetPlaylists 
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
            List<Playlist> playlists = await appController.GetPlaylists(UserId);    

            PlaylistView.GetSpotifyItemList(playlists.Cast<SpotifyItem>().ToList(),PlaylistPageFrame.NavigationService);
            
            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
        }

        
    }
}
