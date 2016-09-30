using System;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;

namespace SmartArchive.Windows {
    public partial class LoginWindow {
        // boolean used by MainWindow to determinate if login was successful
        public bool LoginSuccess;
        
        public LoginWindow() {
            InitializeComponent();
            Topmost = true;

            // Loads Settings from cold storage
            SmartSettings.Default.Reload();

            // If autologin is activated, try to login if login fails it may have been deleted from sql
            if (SmartSettings.Default.AutoLogin) {
                try {
                    Login(SmartSettings.Default.username, SmartSettings.Default.password);
                }
                catch (Exception) {
                    // resets settings and restarts the program, showing the login screen again
                    SmartSettings.Default.Reset();
                    Util.Restart();
                }
            }
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e) {
            Login(UsernameInput.Text, PasswordInput.Password);
        }

        private async void Login(string username, string password) {
            // AuthUser returns different LoginStates, this is used for error handling
            switch (Util.AuthUser(username, password)) {
                case Util.LoginState.Success:
                    LoginSuccess = true;
                    if (RememberCheckBox.IsChecked == true) {
                        SmartSettings.Default.username = UsernameInput.Text;
                        SmartSettings.Default.password = PasswordInput.Password;
                        SmartSettings.Default.AutoLogin = true;
                        SmartSettings.Default.Save();
                    }
                    Close();
                    break;
                case Util.LoginState.UserDoesNotExist:
                    // If user doesn't exist, prompt the user to register
                    // This is using the asyncronous operator await which awaits the ShowMessage task for returning a value
                    var result = await this.ShowMessageAsync("Login Failed", "Username does not exist\nDo you wish to register?", MessageDialogStyle.AffirmativeAndNegative);

                    if (result == MessageDialogResult.Affirmative) {
                        switch (Util.CreateUser(username, password)) {
                            case Util.RegisterState.Success:
                                await this.ShowMessageAsync("Success", "User registered");
                                break;
                            case Util.RegisterState.ConnectionFailed:
                                await this.ShowMessageAsync("Oops", "Connection failed");
                                break;
                            case Util.RegisterState.UsernameTooLong:
                                await this.ShowMessageAsync("Oops", "Username too long");
                                break;
                            case Util.RegisterState.UsernameTooShort:
                                await this.ShowMessageAsync("Oops", "Username too short");
                                break;
                            case Util.RegisterState.PasswordDoesNotMeetCriteria:
                                await this.ShowMessageAsync("Oops", "Password must be 4 or more characters");
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

        // Empties UsernameInput if it has default text
        private void UsernameInput_OnGotFocus(object sender, RoutedEventArgs e) {
            if (UsernameInput.Text == "Username...") {
                UsernameInput.Text = string.Empty;
                UsernameInput.FontStyle = FontStyles.Normal;
            }
        }

        // Resets UsernameInput to default text if it is empty or contains a single space
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