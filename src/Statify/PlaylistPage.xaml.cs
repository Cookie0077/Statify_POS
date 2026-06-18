#region

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Statifylib.Data.Models;
using Statifylib.Domain;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for PlaylistPage.xaml
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



            PlaylistView.GetSpotifyItemList(playlists.Cast<SpotifyItem>().ToList(),PlaylistPageFrame.NavigationService,UserId);
            

            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
        }
    }
}