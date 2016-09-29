using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SmartArchive.Windows {
    public partial class MainWindow {
        private bool _leftMenuVisible;

        public string Username {
            get { return Util.Username; }
        }

        // TODO Make and update comments!
        public MainWindow() {
            // Creates new instance of LoginWindow
            var loginWindow = new LoginWindow();

            // Hides MainWindow
            Hide();

            // Handles if the user has enabled Autologin
            if (!SmartSettings.Default.AutoLogin) {
                loginWindow.Show();
            }
            else {
                Show();
            }

            InitializeComponent();
            DataContext = this;

            FileTypeList.Add("txt");
            FileTypeList.Add("png");
            FileTypeList.Add("jpg");
            FileTypeList.Add("gif");
            FileTypeList.Add("tiff");
            FileTypeList.Add("zip");
            FileTypeList.Add("rar");

            // Shows mainwindow if login is successful or closes program
            loginWindow.Closed += delegate {
                if (loginWindow.LoginSuccess) {
                    Show();
                }
                else {
                    Close();
                }
            };
        }

        // List that is used to populate the filetype list in the flyout menu
        public ObservableCollection<string> FileTypeList { get; } = new ObservableCollection<string>();

        private void FlyOutButton_OnClick(object sender, RoutedEventArgs e) {
            var name = (sender as ToggleButton).Name;

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

        private void SignOutBtn_Click(object sender, RoutedEventArgs e) {
            SmartSettings.Default.Reset();
            Util.Restart();
        }

        private void PopupBox_OnOpened(object sender, RoutedEventArgs e) {
            FloatingActionBtn.Opacity = 0.7;
            FloatActionLabel.Content = "Close";
        }

        private void PopupBox_OnClosed(object sender, RoutedEventArgs e) {
            FloatingActionBtn.Opacity = 1.0;
            FloatActionLabel.Content = "";
        }

        private void AddAction_OnClick(object sender, RoutedEventArgs e) {
            // TODO Add files to list
        }

        private void RemoveAction_OnClick(object sender, RoutedEventArgs e) {
            // TODO Remove files from list
        }

        private void SettingsAction_OnClick(object sender, RoutedEventArgs e) {
            // TODO Open selected file properties
        }
    }
}