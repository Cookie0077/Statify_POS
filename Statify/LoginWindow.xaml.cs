using Statifylib.Data.Models;
using Statifylib.Data.Services.UserService;
using StatifyLib.Data.Models;
using StatifyLib.Data.Services.UserService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Statify
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public User UserAPI;
        private IUserService UserService;

        private bool usefakeService = true;
        public LoginWindow()
        {
            InitializeComponent();

            if (usefakeService)
            {
                UserService = new UserServiceFake();
            }
            else
            {
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri("http://127.0.0.1:8000")
                };

                UserService = new UserService(client);
            }

        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            string pw = TextBoxPassword.Text;


            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pw))
            {
                MessageBox.Show("Please enter a Name AND a password");
                return;
            }
            if(pw.Length <= 0 || pw.Length >= 72)
            {
                MessageBox.Show("Pleas enter a valid Password");
                return;
            }

             UserRequest user = new UserRequest(name,pw);
          

            UserAPI = await UserService.LoginUser(user);
        }
    }
}
