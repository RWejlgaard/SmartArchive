using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;
using Application = System.Windows.Forms.Application;

namespace SmartArchive {
    internal static class Util {

        public enum LoginState {
            Success,
            UserDoesNotExist,
            DetailsIncorrect,
            ConnectionFailed
        }

        public enum RegisterState {
            Success,
            UsernameExists,
            UsernameTooLong,
            UsernameTooShort,
            ConnectionFailed
        }

        private static bool _isConnected;
        private static MySqlConnection _sql;
        public static string Host = "smartarchive.net";
        public static string ConnString = $"Server={Host};Database=smartarchive;Uid=root;Pwd=Password!;";

        private static async void Connect() {
            if (_isConnected) return;

            if (string.IsNullOrEmpty(Host)) {
                MessageBox.Show("Error! Host not set");
            }

            _sql = new MySqlConnection(ConnString);

            try {
                await _sql.OpenAsync();
                _isConnected = true;
            }
            catch (Exception e) {
                _isConnected = false;
                MessageBox.Show(e.ToString());
            }
        }

        private static bool existsInSql(this string username) {
            var selectUsername = new MySqlCommand($"SELECT * FROM smartarchive.logins WHERE username = \"{username}\"", _sql);
            int usernameExists;

            try {
                usernameExists = Convert.ToInt32(selectUsername.ExecuteScalar());
            }
            catch (Exception) {
                return false;
            }

            return usernameExists > 0;
        }

        public static RegisterState CreateUser(string username, string password) {
            Connect();

            RegisterState state;

            if (username.existsInSql()) {
                state = RegisterState.UsernameExists;
            }
            else if (username.Length < 3) {
                state = RegisterState.UsernameTooShort;
            }
            else if (username.Length > 9) {
                state = RegisterState.UsernameTooLong;
            }
            else {
                state = RegisterState.Success;
                var createUser = new MySqlCommand($"INSERT INTO smartarchive.logins (username, password) VALUES(\"{username}\",\"{Sha256(password)}\")", _sql);
                createUser.ExecuteNonQuery();
            }

            return state;
        }

        private static string Sha256(string password) {
            var crypt = new SHA256Managed();
            var hash = string.Empty;
            var crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            return crypto.Aggregate(hash, (current, theByte) => current + theByte.ToString("x"));
        }

        public static string GetFromLoginsSql(string column, string username) {
            Connect();
            var row = new MySqlCommand($"SELECT `{column}` FROM smartarchive.logins where username = \"{username}\"", _sql);

            try {
                var reader = row.ExecuteReader();
                reader.Read();
                row.Dispose();
                return reader.GetString(0);
            }
            catch (Exception) {
                return null;
            }
        }

        public static LoginState AuthUser(string username, string password) {
            Connect();
            var state = LoginState.Success;
            var pass = GetFromLoginsSql("password", username);
            if (pass == null) {
                state =  LoginState.ConnectionFailed;
            }
            else if (Sha256(password) != pass) {
                state = !username.existsInSql() ? LoginState.UserDoesNotExist : LoginState.DetailsIncorrect;
            }

            return state;
        }

        public static void Restart() {
            Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
}