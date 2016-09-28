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
using MahApps.Metro.Controls.Dialogs;
using SmartArchive.Properties;

namespace SmartArchive.Windows {
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow {
        public bool LoginSuccess;
        public bool UsernameRemembrance;

        public LoginWindow() {
            InitializeComponent();
            SmartSettings.Default.Reload();
            if (SmartSettings.Default.AutoLogin)
            {
                Login(SmartSettings.Default.username, SmartSettings.Default.password);
            }
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e) {
            Login(UsernameInput.Text,PasswordInput.Password);
        }

        private async void Login(string username, string password) {
            switch (Util.AuthUser(username, password))
            {
                case Util.LoginState.Success:
                    LoginSuccess = true;
                    if (RememberCheckBox.IsChecked == true)
                    {
                        SmartSettings.Default.username = UsernameInput.Text;
                        SmartSettings.Default.password = PasswordInput.Password;
                        SmartSettings.Default.AutoLogin = true;
                        SmartSettings.Default.Save();
                    }
                    Close();
                    break;
                case Util.LoginState.UserDoesNotExist:
                    var result = await this.ShowMessageAsync("Login Failed", "Username does not exist\nDo you wish to register?", MessageDialogStyle.AffirmativeAndNegative);
                    if (result == MessageDialogResult.Affirmative) {
                        switch (Util.CreateUser(username, password)) {
                            case Util.RegisterState.Success:
                                await this.ShowMessageAsync("Success", "User registered");
                                break;
                            case Util.RegisterState.ConnectionFailed:
                                await this.ShowMessageAsync("Oops","Connection failed");
                                break;
                            case Util.RegisterState.UsernameTooLong:
                                await this.ShowMessageAsync("Oops", "Username too long");
                                break;
                            case Util.RegisterState.UsernameTooShort:
                                await this.ShowMessageAsync("Oops", "Username too short");
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    break;
                case Util.LoginState.DetailsIncorrect:
                    await this.ShowMessageAsync("Login Failed", "Username or password is incorrect");
                    break;
                case Util.LoginState.ConnectionFailed:
                    await this.ShowMessageAsync("Oops", "Connection failed");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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
            if (string.IsNullOrEmpty(PasswordInput.Password)) {
                PasswordInput.Password = "Password";
                PasswordInput.FontStyle = FontStyles.Italic;
            }
        }

        // Listens for Enter keypress in password 
        private void PasswordInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                Login(UsernameInput.Text, PasswordInput.Password);
            }
        }
    }
}