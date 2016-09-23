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

namespace SmartArchive.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool _leftMenuVisible;

        public MainWindow()
        {
            var loginWindow = new LoginWindow(); // Creates new instance of LoginWindow
            Hide(); // Hides MainWindow
            loginWindow.Show(); // Shows LoginWindow

            InitializeComponent();
            
            loginWindow.Closed += delegate {
                if (loginWindow.LoginSuccess)
                {
                    Show();
                }
                else {
                    Close();
                }
            };
        }

        private void LeftMenuButton_OnClick(object sender, RoutedEventArgs e)
        {
            _leftMenuVisible = !_leftMenuVisible;
            foLeftMenu.IsOpen = _leftMenuVisible;
        }
    }
}