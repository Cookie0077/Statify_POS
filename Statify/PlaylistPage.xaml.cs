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
        
        
        public PlaylistPage(int UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
            DataContext = this;
            InitUI();
        }

        public async void InitUI()
        {
            List<Playlist> playlists = await appController.GetPlaylists(UserId);

            foreach (Playlist playlist in playlists)
            {
                TopPlaylists.Add(playlist);
            }
        }
    }
}
