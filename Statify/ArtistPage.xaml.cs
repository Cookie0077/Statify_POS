using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Statifylib.Data.Models;
using Statifylib.Domain;

namespace Statify
{
    /// <summary>
    /// Interaction logic for ArtistPage.xaml
    /// </summary>
    public partial class ArtistPage : Page
    {
        private AppController appController = new();
        
        public ISeries[] ArtistSeries { get; set; }
        public Axis[] XAxes { get; set; }

        private int UserId;
        
        public ArtistPage(int UserId)
        {
            InitializeComponent();
            DataContext = this;
            this.UserId = UserId;
            Loaded += (sender, args) => InitUI();
        }

        public async void InitUI()
        {
            List<Artist> artists = await appController.GetTopArtists(UserId);

            SpotfyItemViewArtists.GetSpotifyItemList(artists.Cast<SpotifyItem>().ToList(), this.NavigationService);

            ArtistSeries = new ISeries[]
            {    
                new ColumnSeries<int>
                {
                    Name = "Plays",
                    Values = artists.Select(t => t.Playtime).ToArray(),
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
        }
            

            

        }
    
    }