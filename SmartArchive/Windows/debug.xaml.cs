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

namespace SmartArchive.Windows
{
    /// <summary>
    /// Interaction logic for debug.xaml
    /// </summary>
    public partial class debug
    {
        public debug()
        {
            InitializeComponent();
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e) {
            
        }



        private void Button_Click(object sender, RoutedEventArgs e) {
            switch (Util.AuthUser("rasmus", "password")) {
                case Util.LoginState.Success:
                    MessageBox.Show("Success");
                    break;
                case Util.LoginState.UserDoesNotExist:
                    MessageBox.Show("USer does not exist");
                    break;
                case Util.LoginState.DetailsIncorrect:
                    MessageBox.Show("Username or password is incorrect");
                    break;
                case Util.LoginState.ConnectionFailed:
                    MessageBox.Show("connection failed");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (Util.CreateUser(usernameInput.Text,PasswordInput.Text)) {
                case Util.RegisterState.Success:
                    MessageBox.Show("Success");
                    break;
                case Util.RegisterState.UsernameExists:
                    MessageBox.Show("Username already exists");
                    break;
                case Util.RegisterState.UsernameTooLong:
                    MessageBox.Show("Username too long");
                    break;
                case Util.RegisterState.UsernameTooShort:
                    MessageBox.Show("Username too short");
                    break;
                case Util.RegisterState.ConnectionFailed:
                    MessageBox.Show("Connexion failed");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
