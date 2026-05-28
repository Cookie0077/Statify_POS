using Statifylib.Data.Models;
using Statifylib.Domain;
using StatifyLib.Data.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    /// 
    public partial class RegisterWindow : Window
    {
        public User NewUser;
        private AppController appController = new AppController(); 
        public RegisterWindow()
        {
            InitializeComponent();
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


            NewUser =  await appController.GetUserRegister(userrequest);
            this.DialogResult = true;
        }
    }
}
