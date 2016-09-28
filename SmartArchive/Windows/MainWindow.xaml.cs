using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private ObservableCollection<string> _fileTypeList = new ObservableCollection<string>();
        public ObservableCollection<string> FileTypeList
        {
            get
            {
                return _fileTypeList;
            }
        }
        private bool _leftMenuVisible;
        
        public MainWindow()
        {
            var loginWindow = new LoginWindow(); // Creates new instance of LoginWindow
            Hide(); // Hides MainWindow
            loginWindow.Show(); // Shows LoginWindow

            InitializeComponent();
            DataContext = this;

            _fileTypeList.Add("txt");
            _fileTypeList.Add("png");
            _fileTypeList.Add("jpg");
            _fileTypeList.Add("gif");
            _fileTypeList.Add("tiff");
            _fileTypeList.Add("zip");
            _fileTypeList.Add("rar");

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

        private void FlyOutButton_OnClick(object sender, RoutedEventArgs e) {
            string name = (sender as ToggleButton).Name;

            _leftMenuVisible = !_leftMenuVisible;
            FlyOutMenu.IsOpen = _leftMenuVisible;

            switch (name) {
                case "FlyOutOpener":
                    FlyOutCloser.IsChecked = _leftMenuVisible;
                    FlyOutOpener.Visibility = Visibility.Hidden;
                    break;
                case "FlyOutCloser":
                    FlyOutOpener.IsChecked = _leftMenuVisible;
                    FlyOutOpener.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}