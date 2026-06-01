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

        public SpotfyItemView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void GetSpotifyItemList(List<SpotifyItem> spotifyItems)
        {
            foreach (SpotifyItem item in spotifyItems)
            {
                SpotifyItems.Add(item);
                if (item.Image == null)
                    continue;

                Image Track_image = new Image()
                {
                    Source = new BitmapImage(new Uri(item.Image)),
                    Width = 15,
                    Height = 15,
                };
                Item_Images.Add(Track_image);
            }

            if (Item_Images.Count == 0)
            {
                ListViewImages.Visibility = Visibility.Hidden;
            } 
                
            
        }
    }
}
