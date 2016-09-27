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
            Util.log = log;
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e) {
            
            Util.Connect();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Util.Connect();
            this.ShowMessageAsync("", Util.AuthUser("rasmus", "passowrdosjfsidaifdoj") ? "Login Successful" : "Login Failed!");
        }
    }
}
