using System;
using Models;
using DataBase;
using MySqlConnector;
using System.Windows.Controls;
using System.Security;
using System.Runtime.InteropServices;
using System.Windows;
using Employees.ViewModels.Base;

namespace Employees.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private ConnectionString connectionString;
        private Main main;
        private User user;

        #region Phone Number
        /// <summary>
        /// phone number property
        /// </summary>
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

        #endregion
        public RelayCommand ExecuteLogin { get; private set; }
        public MainWindowViewModel()
        {
            connectionString = new ConnectionString();
            user = new User();
            ExecuteLogin = new RelayCommand(checkUser);
        }

        #region Converter to unsecure string
        /// <summary>
        /// Convering secure password from password box
        /// to unsecure string
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>

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
        #endregion

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
                //VM не должен запускать окна, это противоречит mvvm
                main = new Main();
                System.Windows.Application.Current.MainWindow.Close();
                main.Show();
            }
            else
                MessageBox.Show("Your password or login is not correct :D " + user.Password, "Display");

        }
    }
}
