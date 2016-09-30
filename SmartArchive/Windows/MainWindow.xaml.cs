using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using Microsoft.Win32;

namespace SmartArchive.Windows {
    public partial class MainWindow {
        // Dynamic list containing File class as type. Bound to the FileView control
        public ObservableCollection<File> FileListCollection { get; } = new ObservableCollection<File>();
        // Dynamic list that is used to populate the filetype list in the flyout menu. Bound to the FileTypeSelection control
        public ObservableCollection<string> FileTypeList { get; } = new ObservableCollection<string>();

        // Custom type which contains icon, name and bytesize of added file
        public class File {
            public ImageSource FileIcon { get; set; }
            public string FileName { get; set; }
            public string FileSize { get; set; }
        }

        // string containing username of current user. Bound to a Username label
        public string Username {
            get { return Util.Username; }
        }

        // boolean which determines if the FlyOut menu is visible
        private bool _leftMenuVisible;

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

        // Shows/Hides and sets IsChecked on MainWindow FlyOutOpener togglebutton
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

        // Closes and restarts application
        private void SignOutBtn_Click(object sender, RoutedEventArgs e) {
            SmartSettings.Default.Reset();
            Util.Restart();
        }

        // Sets opacity and content on controls regarding FloatingAction
        private void PopupBox_OnOpened(object sender, RoutedEventArgs e) {
            FloatingActionBtn.Opacity = 0.7;
            FloatActionLabel.Content = "Close";
        }
        private void PopupBox_OnClosed(object sender, RoutedEventArgs e) {
            FloatingActionBtn.Opacity = 1.0;
            FloatActionLabel.Content = "";
        }

        // Shows/hides ArchiveEmptyBtn
        private void FileView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            ArchiveEmptyBtn.Visibility = FileView.Items.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        }
        
        public static ImageSource GetIcon(string fileName) {
            // Extracts icon from filepath
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
            // Returns BitmapSource as icon
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                new Int32Rect(0, 0, icon.Width, icon.Height),
                BitmapSizeOptions.FromEmptyOptions());
        }

        // Adds files to FileListCollection
        private void AddAction_OnClick(object sender, RoutedEventArgs e) {
            // Opens Windows Explorer File Dialog window for simple selection
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true) {
                foreach (var path in openFileDialog.FileNames) {
                    long tempSize = new FileInfo(path).Length;
                    string Extension = Path.GetExtension(path);

                    // Adds file extension to FileTypeList if it does not already contains it
                    if (!FileTypeList.Contains(Extension)) {
                        FileTypeList.Add(Extension);
                    }

                    // Adds new File to FileListCollection with provided information
                    FileListCollection.Add(new File {
                        FileIcon = GetIcon(path),
                        FileName = Path.GetFileName(path),
                        FileSize = Util.BytesToSizeUnit(tempSize)
                    });
                }
            }

            // Sets selected index of FileView for easier control of ArchiveEmptyBtn
            if (FileView.Items.Count > 0) {
                FileView.SelectedIndex = FileView.Items.Count - 1;
            }
        }

        // Removes SelectedIndex of FileView from FileListCollection
        private void RemoveAction_OnClick(object sender, RoutedEventArgs e) {
            if (FileView.SelectedItems.Count > 0) {
                var tempIndex = FileView.SelectedIndex;
                var tempTotal = FileView.Items.Count;
                FileListCollection.RemoveAt(FileView.SelectedIndex);

                // Makes sure selected index is not over or under FileListcollection size
                if (tempIndex + 1 != tempTotal) {
                    FileView.SelectedIndex = tempIndex;
                }
                else {
                    FileView.SelectedIndex = FileView.Items.Count - 1;
                }
            }
        }

        private void SettingsAction_OnClick(object sender, RoutedEventArgs e) {
            // TODO Open selected file properties
        }
    }
}