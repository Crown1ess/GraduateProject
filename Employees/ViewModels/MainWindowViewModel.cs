using System;
using Models;
using DataBase;
using MySqlConnector;
using System.Windows.Controls;
using System.Security;
using System.Runtime.InteropServices;
using System.Windows;
using Employees.ViewModels.Base;
using Employees.Services.WindowService;
using Employees.Views.Windows;

namespace Employees.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private ConnectionString connectionString;
        private Main main;
        private User user;
        private WindowService windowService;

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

        #region constructor
        public MainWindowViewModel()
        {
            openManageEmployeeWindowCommand = new RelayCommand(DisplayWindow, checkUser);
        }
        
        #endregion

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

        #region Open manage employee window
        /// <summary>
        /// To open window where we can manage and see more information about employee
        /// </summary>
        private readonly RelayCommand openManageEmployeeWindowCommand;
        public RelayCommand OpenManageEmployeeWindowCommand => openManageEmployeeWindowCommand;

        private void DisplayWindow(object parameter)
        {
            windowService = new WindowService();
            windowService.ShowWindow<Main>(new EmployeeViewModel());
            OnClosingRequest();
        }

        /// <summary>
        /// Checking authorization data
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool checkUser(object parameter)
        {
            user = new User();
            connectionString = new ConnectionString();

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
                    return true;
                }
                else return false;
            }
        }
        #endregion
    }
}
