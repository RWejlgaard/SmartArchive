using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;

namespace SmartArchive {
    static class Util {
        private static bool _isConnected;
        private static MySqlConnection _sql;

        public static string Host = "smartarchive.net";
        public static string ConnString = $"Server={Host};Database=smartarchive;Uid=root;Pwd=Password!;";

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
            try
            {
                usernameExists = Convert.ToInt32(selectUsername.ExecuteScalar());
            }
            catch (Exception) {
                return false;
            }
            return usernameExists > 0;
        }

        public static RegisterState CreateUser(string username, string password) {
            Connect();
            username = username.ToUpper();
            

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

        public static LoginState AuthUser(string username, string password) {
            Connect();
            username = username.ToUpper();
            var getUserRow = new MySqlCommand($"SELECT `password` FROM smartarchive.logins where username = \"{username}\"", _sql);
            MySqlDataReader reader = null;
            var state = LoginState.Success;

            try {
                reader = getUserRow.ExecuteReader();
                reader.Read();
            }
            catch (Exception) {
                state = LoginState.ConnectionFailed;
            }

            var pass = "";

            try {
                pass = reader.GetString(0);
            }
            catch (Exception) {
                state = LoginState.UserDoesNotExist;
            }

            var hash = Sha256(password);

            if (hash != pass) {
                state = !username.existsInSql() ? LoginState.UserDoesNotExist : LoginState.DetailsIncorrect;
            }

            getUserRow.Dispose();
            reader.Dispose();

            return state;
        }
    }
}