using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace SmartArchive {
    static class Util {
        private static bool IsConnected = false;
        private static MySqlConnection Sql;
        
        public static string host = "smartarchive.net";
        public static string connString = $"Server={host};Database=smartarchive;Uid=root;Pwd=Password!;";

        public static async void Connect(int SqlPort = 3306, int FtpPort = 21) {
            if (IsConnected) return;
            if (string.IsNullOrEmpty(host)) {
                MessageBox.Show("Error! Host not set");
            }
            Sql = new MySqlConnection(connString);
            try {
                await Sql.OpenAsync();
                IsConnected = true;
            }
            catch (Exception e) {
                IsConnected = false;
                MessageBox.Show(e.ToString());
                return;
            }
            
            
        }

        public static void CreateUser(string username, string password) {

        }

        public static bool AuthUser(string username, string password){
            var getUserRow = new MySqlCommand($"SELECT `password` FROM smartarchive.logins where username = \"{username}\"", Sql);
            var reader = getUserRow.ExecuteReader();
            reader.Read();
            var pass = "";
            try {
                pass = reader.GetString(0);
            }
            catch (Exception) {
                MessageBox.Show("Username does not exist");
                return false;
            }
            return password == pass;
        }
    }
}