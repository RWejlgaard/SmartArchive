using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using MySql.Data.MySqlClient;
using Application = System.Windows.Forms.Application;

namespace SmartArchive {
    internal static class Util {

        // Enum used as return type in AuthUser
        public enum LoginState {
            Success,
            UserDoesNotExist,
            DetailsIncorrect,
            ConnectionFailed
        }

        // Enum used as return type in CreateUser
        public enum RegisterState {
            Success,
            UsernameExists,
            UsernameTooLong,
            UsernameTooShort,
            PasswordDoesNotMeetCriteria,
            ConnectionFailed
        }

        // Readonly array that contains size units
        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        // Database variables
        private static bool _isConnected;
        private static MySqlConnection _sql;
        public static string Host = "smartarchive.net";
        public static string ConnString = $"Server={Host};Database=smartarchive;Uid=root;Pwd=Password!;";

        // Persistant variables
        public static string Username;

        // Establishes active connection to SQL
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
            catch (Exception) {
                _isConnected = false;
            }
        }

        // extension function for string to return true if username exists
        private static bool existsInSql(this string username) {
            var selectUsername = new MySqlCommand($"SELECT * FROM smartarchive.logins WHERE username = \"{username}\"",
                _sql);
            int usernameExists;

            try {
                usernameExists = Convert.ToInt32(selectUsername.ExecuteScalar());
            }
            catch (Exception) {
                selectUsername.Dispose();
                return false;
            }
            selectUsername.Dispose();
            return usernameExists > 0;
        }

        // Creates user in SQL
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
            else if (password.Length < 4) {
                state = RegisterState.PasswordDoesNotMeetCriteria;
            }
            else {
                state = RegisterState.Success;
                var createUser =
                    new MySqlCommand(
                        $"INSERT INTO smartarchive.logins (username, password) VALUES(\"{username}\",\"{Sha256(password)}\")",
                        _sql);
                createUser.ExecuteNonQuery();
            }

            return state;
        }

        // Takes string input and outputs sha256 sum
        private static string Sha256(string password) {
            var crypt = new SHA256Managed();
            var hash = string.Empty;
            var crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(password), 0, Encoding.ASCII.GetByteCount(password));
            return crypto.Aggregate(hash, (current, theByte) => current + theByte.ToString("x"));
        }

        // Gets the first value in given column based on username, this is primarily used for getting password
        public static string GetFromLoginsSql(string column, string username) {
            Connect();
            var row = new MySqlCommand($"SELECT `{column}` FROM smartarchive.logins where username = \"{username}\"",
                _sql);

            using (MySqlDataReader reader = row.ExecuteReader()) {
                try {
                    reader.Read();
                    return reader.GetString(0);
                }
                catch (Exception) {
                    return null;
                }
            }
        }

        // Authenticates user login information using username and password input
        public static LoginState AuthUser(string username, string password) {
            Connect();
            string pass;
            var state = LoginState.Success;

            try {
                pass = GetFromLoginsSql("password", username);
            }
            catch (Exception) {
                SmartSettings.Default.Reset();
                state = LoginState.ConnectionFailed;
                return state;
            }

            if (Sha256(password) != pass) {
                state = !username.existsInSql() ? LoginState.UserDoesNotExist : LoginState.DetailsIncorrect;
            }

            try {
                Username = FirstCharToUpper(GetFromLoginsSql("username", username));
            }
            catch (Exception) {
                // do nothing
            }

            return state;
        }

        // Returns input with upper case first letter
        public static string FirstCharToUpper(string input) {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        // Uses SizeSuffix to format number of bytes to normal size format
        public static string BytesToSizeUnit(long bytes) {
            if (bytes < 0) {
                return "-" + BytesToSizeUnit(-bytes);
            }
            if (bytes == 0) {
                return "0.0 bytes";
            }

            var mag = (int) Math.Log(bytes, 1024);
            var adjustedSize = (decimal) bytes/(1L << (mag*10));

            return $"{adjustedSize:n1} {SizeSuffixes[mag]}";
        }

        // Restarts application
        public static void Restart() {
            Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
}