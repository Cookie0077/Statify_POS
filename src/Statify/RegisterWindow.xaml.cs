#region

using System.Windows;
using Serilog;
using Statifylib.Data.Models;
using StatifyLib.Data.Models;
using Statifylib.Domain;

#endregion

namespace Statify
{
    /// <summary>
    ///     Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public User NewUser;
        private AppController appController;

        public RegisterWindow(AppController appController)
        {
            InitializeComponent();
            this.appController = appController;
            TextBoxName.Focus();
        }

        private async void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            string pw = PasswordBoxPW.Password;
            string pwRe = PasswordBoxPWRE.Password;


            if (string.IsNullOrEmpty(name) == true || string.IsNullOrEmpty(pw) == true || string.IsNullOrEmpty(pwRe))
            {
                MessageBox.Show("Please enter a Name AND a password");
                return;
            }

            if (pw.Length <= 0 || pw.Length > 72)
            {
                MessageBox.Show("Pleas enter a valid Password");
                return;
            }

            if (pw != pwRe)
            {
                MessageBox.Show("Both Password must be the same");
                return;
            }

            UserRequest userrequest = new UserRequest(name, pw);


            NewUser = await appController.GetUserRegister(userrequest);
            Log.Logger.Information("User registered");
            this.DialogResult = true;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            this.Close();

            // With this.Close() the application will not close
            // And you would get into the App without logging in
        }
    }
}