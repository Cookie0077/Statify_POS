#region

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Serilog;
using Statifylib.Data.Models;

#endregion

namespace Statify;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private MainPage mainPage;
    private ArtistPage artistPage;
    private TrackPage trackPage;
    private PlaylistPage playlistPage;
    private User CurentUser;

    private bool loginwindowoff = false;

    public MainWindow()
    {
        InitializeComponent();

        if (!loginwindowoff)
        {
            LoginWindow loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                CurentUser = loginWindow.UserAPI;
                mainPage = new MainPage(CurentUser.Id);
                artistPage = new ArtistPage(CurentUser.Id);
                trackPage = new TrackPage(CurentUser.Id);
                playlistPage = new PlaylistPage(CurentUser.Id);
                Labelusername.Content = CurentUser.Name;
                if (CurentUser.Image == null)
                    ImageProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/user.png"));

                else
                    ImageProfile.Source = new BitmapImage(new Uri(CurentUser.Image));
                Log.Logger.Debug("Initialized with login");
                Log.Logger.Information("User logged in: {Name}", CurentUser.Name);
            }
        }
        else
        {
            mainPage = new MainPage(1);
            artistPage = new ArtistPage(1);
            trackPage = new TrackPage(1);
            playlistPage = new PlaylistPage(1);
            Log.Logger.Debug("Initialized without login");
        }

        Mainframe.Navigate(mainPage);
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl tabControl)
        {
            TabItem selectedTab = tabControl.SelectedItem as TabItem;

            switch (selectedTab.Name)
            {
                case "TabHome":
                    Mainframe.Navigate(mainPage);
                    Log.Logger.Debug("Navigated to Home");
                    break;

                case "ArtistTab":
                    Mainframe.Navigate(artistPage);
                    Log.Logger.Debug("Navigated to Artists");
                    break;


                case "SongTabs":
                    Mainframe.Navigate(trackPage);
                    Log.Logger.Debug("Navigated to Songs");
                    break;


                case "PlaylistTab":
                    Mainframe.Navigate(playlistPage);
                    Log.Logger.Debug("Navigated to Playlists");
                    break;
            }
        }
    }

    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void Labelusername_Click(object sender, RoutedEventArgs e)
    {
        UserDropdownPopup.IsOpen = !UserDropdownPopup.IsOpen;
    }

    private void ButtonLogout_OnClick(object sender, RoutedEventArgs e)
    {
        UserDropdownPopup.IsOpen = false;

        this.Hide(); 

        LoginWindow loginWindow = new LoginWindow();
        if (loginWindow.ShowDialog() == true)
        {
            CurentUser = loginWindow.UserAPI;
            mainPage = new MainPage(CurentUser.Id);
            artistPage = new ArtistPage(CurentUser.Id);
            trackPage = new TrackPage(CurentUser.Id);
            playlistPage = new PlaylistPage(CurentUser.Id);
            Labelusername.Content = CurentUser.Name;

            if (CurentUser.Image == null)
                ImageProfile.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/user.png"));
            else
                ImageProfile.Source = new BitmapImage(new Uri(CurentUser.Image));

            Log.Logger.Information("User logged in: {Name}", CurentUser.Name);
            Mainframe.Navigate(mainPage); 
            this.Show(); 
        }
        else
        {
            Application.Current.Shutdown();
        }
    }


    private void ButtonChangeNaem_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }



}