using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartArchive.Windows {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow {
        public bool LoginSuccess;
        public bool UsernameRemembrance;

        public LoginWindow() {
            InitializeComponent();
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e) {
            LoginSuccess = true;
            Close();
        }

        private void UsernameInput_OnGotFocus(object sender, RoutedEventArgs e) {
            if (UsernameInput.Text == "Username...") {
                UsernameInput.Text = string.Empty;
                UsernameInput.FontStyle = FontStyles.Normal;
            }
        }

        private void UsernameInput_OnLostFocus(object sender, RoutedEventArgs e) {
            if (UsernameInput.Text == string.Empty || UsernameInput.Text == " ") {
                UsernameInput.Text = "Username...";
                UsernameInput.FontStyle = FontStyles.Italic;
            }
        }

        private void PasswordInput_OnGotFocus(object sender, RoutedEventArgs e) {
            if (PasswordInput.Password == "Password") {
                PasswordInput.Password = string.Empty;
                PasswordInput.FontStyle = FontStyles.Normal;
            }
        }

        private void PasswordInput_OnLostFocus(object sender, RoutedEventArgs e) {
            if (PasswordInput.Password == string.Empty || PasswordInput.Password == " ") {
                PasswordInput.Password = "Password";
                PasswordInput.FontStyle = FontStyles.Italic;
            }
        }
    }
}