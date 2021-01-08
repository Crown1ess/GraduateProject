using System;
using Models;
using DataBase;
using MySqlConnector;
using System.Windows.Controls;
using System.Security;
using System.Runtime.InteropServices;
using System.Windows;

namespace Employees
{
    public class UserViewModel : NotifyPropertyChange
    {
        private ConnectionString connectionString;
        private Main main;
        private User user;

        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set 
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public RelayCommand ExecuteLogin { get; set; }
        public UserViewModel()
        {
            connectionString = new ConnectionString();
            user = new User();
            ExecuteLogin = new RelayCommand(checkUser);
        }

        private string convertToUnsecureString(SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        private void checkUser(object parameter)
        {
            bool check = false;

            user.PhoneNumber = PhoneNumber;

            var passwordContainer = (parameter as PasswordBox).SecurePassword;
            user.Password = passwordContainer != null ? convertToUnsecureString(passwordContainer) : user.Password = null;
            
            string sqlInquiryString = $"SELECT * FROM users where phone_number = '{user.PhoneNumber}' AND password = '{user.Password}'";
            using var connection = new MySqlConnection(connectionString.StringOfConnection);
            connection.Open();

            MySqlCommand command = new MySqlCommand(sqlInquiryString, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    check = true;
                }
            }

            if (check == true)
            {
                main = new Main();
                System.Windows.Application.Current.MainWindow.Close();
                main.Show();
            }
            else
                MessageBox.Show("Your password or login is not correct :D " + user.Password, "Display");

        }
    }
}
