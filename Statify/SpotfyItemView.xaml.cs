using Statifylib.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using StatifyLib.Data.Models;
using Track = Statifylib.Data.Models.Track;

namespace Statify
{
    /// <summary>
    /// Interaction logic for SpotfyItemView.xaml
    /// </summary>
    public partial class SpotfyItemView : UserControl
    {
        public ObservableCollection<SpotifyItem> SpotifyItems { get; private set; } =
            new ObservableCollection<SpotifyItem>();
      
        public ObservableCollection<Image> Item_Images { get; private set; } = new ObservableCollection<Image>();

        private NavigationService _navigationService;

        public SpotfyItemView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void GetSpotifyItemList(List<SpotifyItem> spotifyItems,NavigationService parenNavigationService)
        {
            _navigationService = parenNavigationService;
            foreach (SpotifyItem item in spotifyItems)
            {
                SpotifyItems.Add(item);
                if (item.Image == null)
                    continue;

                Image Track_image = new Image()
                {
                    Source = new BitmapImage(new Uri(item.Image)),
                    Width = 30,
                    Height = 30,
                    Stretch = Stretch.Uniform,

                };
                Item_Images.Add(Track_image);
            }

            if (Item_Images.Count == 0)
            {
                ListViewImages.Visibility = Visibility.Hidden;
            } 
                
            
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            SpotifyItem item = ListviewItems.SelectedItem as SpotifyItem;
            if (_navigationService == null) return;

            if (item is TrackRecord)
            {
                _navigationService.Navigate(new TrackDetailPage(item as TrackRecord));
            }

        }
    }
}
