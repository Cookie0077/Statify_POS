using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Statifylib.Data.Models;
using Statifylib.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using StatifyLib.Data.Models;

namespace Statify
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
    private AppController appController = new AppController();

    public ObservableCollection<Artist> Topartists { get; private set; } = new ObservableCollection<Artist>();
    
    // Now with the Placount and stuff its "TrackRecord"
    public ObservableCollection<TrackRecord> TopTracks { get; private set; } = new ObservableCollection<TrackRecord>();
    //public ObservableCollection<Track> TopTracks { get; private set; } 

    public ObservableCollection<Image> Track_Images { get; private set; } = new ObservableCollection<Image>();

    public ISeries[] TrackSeries { get; set; }
    private int UserId;

   

        public MainPage(int userId)
    {
        InitializeComponent();
        UserId = userId;
        DataContext = this;
        InitUI();
      
        appController.SyncTracks(userId);
    }

    public async void InitUI()
    {
        List<Artist> artists = await appController.GetTopArtists(UserId);
        //List<Track> tracks = await appController.GetTracks();
        List<TrackRecord> tracks = await appController.GetTopTracks(UserId);


        SpotfyItemViewTopArtists.GetSpotifyItemList(artists.Cast<SpotifyItem>().ToList());

        SpotfyItemViewTopTracks.GetSpotifyItemList(tracks.Cast<SpotifyItem>().ToList());

        TrackSeries = new ISeries[tracks.Count];

        for (int i = 0; i < tracks.Count; i++)
        {
            float hue = (i * 65f) % 360f;


        TrackSeries[i] = new PieSeries<int>()
            {
                Name = tracks[i].Name,
                Values = new int[1] { tracks[i].PlayCount},
                // Hue, Saturation, Lightness
                Fill = new SolidColorPaint(SKColor.FromHsl(hue, 80f, 55f))
            };

            TrackChart.Series = TrackSeries;
        }



    }
    }
}
