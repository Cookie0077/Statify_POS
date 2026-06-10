using Statifylib.Data.Models;
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

namespace Statify;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private MainPage mainPage;
    private ArtistPage artistPage;
    private TrackPage trackPage;
    private PlaylistPage playlistPage;
    private User CurentUser;

    private bool loginwindowoff = true;

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
            }

        }
        else
        {
          
            mainPage = new MainPage(1);
            artistPage = new ArtistPage(1);
            trackPage = new TrackPage(1);
            playlistPage = new PlaylistPage(1);
        }

        Mainframe.Navigate(mainPage);
    }

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.Source is TabControl tabControl)
        {
            TabItem selectedTab = tabControl.SelectedItem as TabItem;

           switch(selectedTab.Name)
            {
                case "TabHome":
                    Mainframe.Navigate(mainPage);
                    break;

                case "ArtistTab":
                    Mainframe.Navigate(artistPage);
                    break;


                case "SongTabs":
                    Mainframe.Navigate(trackPage);
                    break;


                case "PlaylistTab":
                   Mainframe.Navigate(playlistPage);
                   break;



            }
            
        }
    }

    private void ButtonClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}