#region

using System.Windows;
using System.Windows.Controls;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Statifylib.Data.Models;
using Statifylib.Domain;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for ArtistPage.xaml
    /// </summary>
    public partial class ArtistPage : Page
    {
        private AppController appController = new();

        public ISeries[] ArtistSeries { get; set; }
        public Axis[] XAxes { get; set; }

        private int UserId;

        private bool _initialized = false;


        public ArtistPage(int UserId)
        {
            InitializeComponent();
            DataContext = this;
            this.UserId = UserId;
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
            ArtistChart.TooltipTextPaint = new SolidColorPaint(SKColors.White);
            ArtistChart.TooltipBackgroundPaint =
                new SolidColorPaint(new SKColor(0x31, 0x2F, 0x54)); // matches your SurfaceColor
            ArtistChart.LegendTextPaint = new SolidColorPaint(SKColors.White);
            // TODO: Make the Artist names the right color


            List<Artist> artists = await appController.GetTopArtists(UserId);

            SpotfyItemViewArtists.GetSpotifyItemList(artists.Cast<SpotifyItem>().ToList(), this.NavigationService);

            ArtistSeries = new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "Playtime in minutes: ",
                    Values = artists.Select(t => t.Playtime / 60000).ToArray(),
                    Fill = new SolidColorPaint(SKColors.Red)
                }
            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = artists.Select(t => t.Name).ToArray(),
                    LabelsRotation = 270
                }
            };

            ArtistChart.Series = ArtistSeries;
            ArtistChart.XAxes = XAxes;

            LoadingOverlay.Visibility = Visibility.Collapsed;
            ContentGrid.Visibility = Visibility.Visible;
        }
    }
}