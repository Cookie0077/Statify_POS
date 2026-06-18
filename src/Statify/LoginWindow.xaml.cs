#region

using System.Windows;
using Serilog;
using Statifylib.Data.Models;
using StatifyLib.Data.Models;
using Statifylib.Data.Services.UserService;
using Statifylib.Domain;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public User UserAPI;
        private IUserService UserService;
        private AppController appController;

        private bool usefakeService = true;

        public LoginWindow(AppController appController)
        {
            InitializeComponent();
            this.appController = appController;
            TextBoxName.Focus();
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            string pw = PasswordBoxPW.Password;


            if (string.IsNullOrEmpty(name) == true || string.IsNullOrEmpty(pw) == true)
            {
                Log.Logger.Error("No Name or Password entered");
                MessageBox.Show("Please enter a Name AND a password");
                return;
            }

            if (pw.Length <= 0 || pw.Length > 72)
            {
                Log.Logger.Error("Invalid Passwordlength");
                MessageBox.Show("Pleas enter a valid Password");
                return;
            }

            UserRequest userrequest = new UserRequest(name, pw);


            UserAPI = await appController.GetUserLogin(userrequest);

            if (UserAPI.Name == null)
            {
                Log.Logger.Error("User not found");
                MessageBox.Show("Wrong Username or Password");
                return;
            }

            Log.Logger.Information("User Succesfully logged in");
            this.DialogResult = true;
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(appController);

            if (registerWindow.ShowDialog() == true)
            {
                UserAPI = registerWindow.NewUser;
                this.DialogResult = true;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            // Close the application

            // With this.Close() the application would not entirely close,
            // and you would get into the App without logging in
        }
    }
}