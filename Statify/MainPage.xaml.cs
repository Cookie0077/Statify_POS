using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Statifylib.Data.Models;
using Statifylib.Domain;
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

namespace Statify
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private AppController appController = new AppController();

        public ObservableCollection<Artist> Topartists { get; private set; }
        public ObservableCollection<Track> TopTracks { get; private set; }

        public ISeries[] TrackSeries { get; set; }
        public Axis[] XAxes { get; set; }
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            InitUI();

        }

        public async void InitUI()
        {
            List<Artist> artists = await appController.GetArtists();
            List<Track> tracks = await appController.GetTracks();

            TopTracks = new ObservableCollection<Track>(tracks);
            Topartists = new ObservableCollection<Artist>(artists);

            TrackSeries = new ISeries[]
            {    
                new ColumnSeries<int>
                {
                Name = "Plays",
                // TODO: hier muss die playtime hin !!
                Values = tracks.Select(t => t.Id).ToArray(),
                Fill = new SolidColorPaint(SKColors.Green)
                }


            };

            XAxes = new Axis[]
            {
                new Axis
                {
                     Labels = tracks.Select(t => t.Name).ToArray(),
                     LabelsRotation = 45
                }
            };

        }
    }
}
